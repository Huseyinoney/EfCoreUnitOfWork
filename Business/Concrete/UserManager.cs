using Business.Abstract;
using Business.Abstract.UnitOfWork;
using Business.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
       
        private readonly IPasswordHashHelper passwordHashHelper;
        private readonly IUnitOfWork unitOfWork;

        public UserManager(IPasswordHashHelper passwordHashHelper, IUnitOfWork unitOfWork)
        {

            this.passwordHashHelper = passwordHashHelper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> AddUser(string Name, string Password)
        {
            try
            {
                User user = new User();
                user.Name = Name;
                user.Password = passwordHashHelper.HashPassword(Password);
                var response = await unitOfWork.Users.AddAsync(user);
               await unitOfWork.SaveChangeAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı Eklenirken Bir Hata Oluştu", ex);
            }
        }

        public async Task<bool> DeleteUser(string Name)
        {
            try
            {
                User user = await unitOfWork.Users.GetAsync(n => n.Name == Name);
                var response = await unitOfWork.Users.DeleteAsync(user);
                await unitOfWork.SaveChangeAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı Silinirken Bir Hata Oluştu", ex);
            }
        }

        public async Task<User> GetUser(int id)
        {
            try
            {
                User user = await unitOfWork.Users.GetAsync(u => u.Id == id);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Kullanıcı Bulunurken Bir Hata Oluştu", ex);
            }
        }
    }
}

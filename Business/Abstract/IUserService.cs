using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        public Task<bool> AddUser(string Name, string Password);
        public Task<bool> DeleteUser(string Name);
        public Task<User> GetUser(int id);

    }
}

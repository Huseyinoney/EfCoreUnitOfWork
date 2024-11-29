using Business.Abstract.UnitOfWork;
using Business.Repositories;
using Core.Repositories.EntityFramework;
using DataAccess.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext dbContext;
        public IBaseRepository<User> Users { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            Users = new GenericBaseRepository<User, ApplicationDbContext>(dbContext);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}

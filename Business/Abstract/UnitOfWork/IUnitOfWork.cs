using Business.Repositories;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<User> Users { get; }
        Task<int> SaveChangeAsync();
    }
}

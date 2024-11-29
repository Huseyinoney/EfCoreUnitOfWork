using Business.Repositories;
using Core.Entities;
using Core.Repositories.EntityFramework;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BaseRepository<T, TContext> : GenericBaseRepository<T, TContext>, IBaseRepository<T> where T : class, IEntity, new() where TContext : DbContext

    {
        public BaseRepository(TContext context) : base(context) { }
    }
}

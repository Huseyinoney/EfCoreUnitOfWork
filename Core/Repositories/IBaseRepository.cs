﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public interface IBaseRepository<T> where T : class, IEntity, new()
    {
        public Task<bool> AddAsync(T Entity);
        public Task<bool> DeleteAsync(T Entity);
        public Task<T> GetAsync(Expression<Func<T, bool>> filter);
    }
}

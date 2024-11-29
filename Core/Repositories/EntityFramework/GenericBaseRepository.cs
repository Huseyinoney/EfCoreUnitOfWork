using Business.Repositories;
using Core.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.EntityFramework
{
    public class GenericBaseRepository<T, TContext> : IBaseRepository<T> where T : class, IEntity, new() where TContext : DbContext
    {
        private TContext _DbContext;
        public GenericBaseRepository(TContext context)
        {
            this._DbContext = context;
        }

        public async Task<bool> AddAsync(T Entity)
        {
            try
            {
                var response = await _DbContext.Set<T>().AddAsync(Entity);
                if (response is not null)
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(T Entity)
        {
            try
            {
                var response = _DbContext.Set<T>().Remove(Entity);
                if (response is not null) 
                {
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return false;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var response = await _DbContext.Set<T>().FirstOrDefaultAsync(filter);
                if (response is not null)
                {
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return null;
            }
        }
    }
}

using DataAccess.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User, ApplicationDbContext>
    {
        public UserRepository(ApplicationDbContext context) : base(context){}
    }
}

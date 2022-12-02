using Ebebul.Core.Models;
using Ebebul.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> GetUsersWithCategory()
        {
            //Eager Loading ->İlk userlar cekilir.
            return await _context.Users.Include(x=> x.Category).ToListAsync();  
        }
    }
}

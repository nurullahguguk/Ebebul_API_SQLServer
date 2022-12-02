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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithUsersAsync(int categoryId)
        {
            return await _context.Categories.Include(x => x.Users).Where(x => x.Id == categoryId).SingleOrDefaultAsync();   
        }
    }
}

using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithUsersDto>> GetSingleCategoryByIdWithUsersAsync(int categoryId);
    }
}

using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.Services
{
    public interface IUserService : IService<User>
    {
        Task<CustomResponseDto<List<UserWithCategoryDto>>> GetUsersWithCategory();
    }
}

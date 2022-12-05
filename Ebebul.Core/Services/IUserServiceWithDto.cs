using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Core.Services
{
    public interface IUserServiceWithDto : IServiceWithDto<User, UserDto>
    {
        Task<CustomResponseDto<List<UserWithCategoryDto>>> GetUsersWithCategory();

        Task<CustomResponseDto<NoContentDto>> UpdateAsync(UserUpdateDto dto);

        Task<CustomResponseDto<UserDto>> AddAsync(UserCreateDto dto);
    }
}

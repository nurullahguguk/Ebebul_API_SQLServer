using AutoMapper;
using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using Ebebul.Core.Repositories;
using Ebebul.Core.Services;
using Ebebul.Core.UnitofWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Service.Services
{
    public class UserServiceWithDto : ServiceWithDto<User, UserDto>, IUserServiceWithDto
    {
        private readonly IUserRepository _userRepository;
        public UserServiceWithDto(IGenericRepository<User> repository, IUnitofWork unitofWork,
            IMapper mapper, IUserRepository userRepository) : base(repository, unitofWork, mapper)
        {
            _userRepository = userRepository;
        }

        public async Task<CustomResponseDto<UserDto>> AddAsync(UserCreateDto dto)
        {
            var newEntity = _mapper.Map<User>(dto);
            await _userRepository.AddAsync(newEntity);
            await _unitofWork.CommitAsync();

            var newDto = _mapper.Map<UserDto>(newEntity);
            return CustomResponseDto<UserDto>.Success(StatusCodes.Status200OK, newDto);
        }

        public async Task<CustomResponseDto<List<UserWithCategoryDto>>> GetUsersWithCategory()
        {
            var users = await _userRepository.GetUsersWithCategory();

            var usersDto = _mapper.Map<List<UserWithCategoryDto>>(users);
            return CustomResponseDto<List<UserWithCategoryDto>>.Success(200, usersDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(UserUpdateDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            _userRepository.Update(entity);

            await _unitofWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent);
        }
    }
}

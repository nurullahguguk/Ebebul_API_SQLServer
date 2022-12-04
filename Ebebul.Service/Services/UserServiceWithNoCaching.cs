using AutoMapper;
using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using Ebebul.Core.Repositories;
using Ebebul.Core.Services;
using Ebebul.Core.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Service.Services
{
    public class UserServiceWithNoCaching : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;   
        private readonly IMapper _mapper;
        public UserServiceWithNoCaching(IGenericRepository<User> repository, IUnitofWork unitofwork, IUserRepository 
            userRepository, IMapper mapper) : base(repository, unitofwork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<UserWithCategoryDto>>> GetUsersWithCategory()
        {
            var users = await _userRepository.GetUsersWithCategory();

            var usersDto = _mapper.Map<List<UserWithCategoryDto>>(users);
            return CustomResponseDto<List<UserWithCategoryDto>>.Success(200, usersDto);
        }
    }
}

﻿using AutoMapper;
using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using Ebebul.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebebul.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IService<User> service, IUserService userService = null)
        {
            _mapper = mapper;
            _service = service;
            _userService = userService;
        }

        /// GET api/users
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var users = await _service.GetAllAsync();
            var usersDtos = _mapper.Map<List<UserDto>>(users.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDtos));
        }

        /// GET api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, usersDto));
        }

        //GET api/users/GetUsersWithCategory
        //[HttpGet("GetUsersWithCategory")] => Defaul denilebilir
        [HttpGet("[action]")] //GetUsersWithGategory method ismini otomotik alır.
        public async Task<IActionResult> GetUsersWithGategory()
        {
            return CreateActionResult(await _userService.GetUsersWithCategory());
        }
        //
        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = await _service.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, usersDto));
        }

        //
        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userDto)
        {
            await _service.UpdateAsync(_mapper.Map<User>(userDto));
            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        //DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);
            
            await _service.RemoveAsync(user);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}

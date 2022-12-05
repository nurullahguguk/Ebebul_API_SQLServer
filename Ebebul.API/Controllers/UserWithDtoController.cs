using Ebebul.API.Filters;
using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using Ebebul.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebebul.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWithDtoController : CustomBaseController
    {
        private readonly IUserServiceWithDto _userServiceWithDto;

        public UserWithDtoController(IUserServiceWithDto userServiceWithDto)
        {
            _userServiceWithDto = userServiceWithDto;
        }

        
        
        [HttpGet("[action]")] 
        public async Task<IActionResult> GetUsersWithGategory()
        {
            return CreateActionResult(await _userServiceWithDto.GetUsersWithCategory());
        }
       
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult( await _userServiceWithDto.GetAllAsync());
        }


        [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult( await _userServiceWithDto.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserCreateDto userDto)
        {
            return CreateActionResult(await _userServiceWithDto.AddAsync(userDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto userDto)
        {
            return CreateActionResult(await _userServiceWithDto.UpdateAsync(userDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateActionResult(await _userServiceWithDto.RemoveAsync(id));
        }

        [HttpPost("SaveAll")]
        public async Task<IActionResult> Save(List<UserDto> usersDtos)
        {
            return CreateActionResult(await _userServiceWithDto.AddRangeAsync(usersDtos));
        }

        [HttpDelete("RemoveAll")]
        public async Task<IActionResult> RemoveAll(List<int> ids)
        {
            return CreateActionResult(await _userServiceWithDto.RemoveRangeAsync(ids));
        }

        [HttpDelete("Any/{id}")]
        public async Task<IActionResult> Any(int id)
        {
            return CreateActionResult(await _userServiceWithDto.AnyAsync(x => x.Id == id));
        }
    }
}

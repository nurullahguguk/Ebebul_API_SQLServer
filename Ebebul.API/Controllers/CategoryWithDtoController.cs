using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using Ebebul.Core.Services;
using Ebebul.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebebul.API.Controllers
{
    
    public class CategoryWithDtoController : CustomBaseController
    {
        private readonly IServiceWithDto<Category, CategoryDto> _categoryServiceWithDto;

        public CategoryWithDtoController(IServiceWithDto<Category, CategoryDto> categoryService)
        {
            _categoryServiceWithDto = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResult(await _categoryServiceWithDto.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Get(CategoryDto category)
        {
            return CreateActionResult(await _categoryServiceWithDto.AddAsync(category));
        }
    }
}

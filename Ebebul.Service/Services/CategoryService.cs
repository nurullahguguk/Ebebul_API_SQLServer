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
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitofWork unitofwork, ICategoryRepository categoryRepository = null, IMapper mapper = null) : base(repository, unitofwork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithUsersDto>> GetSingleCategoryByIdWithUsersAsync(int categoryId)
        {
            var cetegory = await _categoryRepository.GetSingleCategoryByIdWithUsersAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithUsersDto>(cetegory);
            return CustomResponseDto<CategoryWithUsersDto>.Success(200, categoryDto);
        }
    }
}

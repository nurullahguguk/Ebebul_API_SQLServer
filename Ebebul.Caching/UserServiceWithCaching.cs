using AutoMapper;
using Ebebul.Core.DTOs;
using Ebebul.Core.Models;
using Ebebul.Core.Repositories;
using Ebebul.Core.Services;
using Ebebul.Core.UnitofWorks;
using Ebebul.Repository.Repositories;
using Ebebul.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ebebul.Caching
{
    public class UserServiceWithCaching : IUserService
    {
        private const string CacherUserKey = "usersCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IUserRepository _userRepository;
        private readonly IUnitofWork _unitofWork;
        public UserServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IUserRepository userRepository, IUnitofWork unitofWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _userRepository = userRepository;
            _unitofWork = unitofWork;

            if (!_memoryCache.TryGetValue(CacherUserKey, out _))
            {
                _memoryCache.Set(CacherUserKey, _userRepository.GetUsersWithCategory().Result);
            }
        }

        public async Task<User> AddAsync(User entity)
        {
            await _userRepository.AddAsync(entity);
            await _unitofWork.CommitAsync();
            await CacheAllUsersAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> AddRangeAsync(IEnumerable<User> entities)
        {
            await _userRepository.AddRangeAsync(entities);
            await _unitofWork.CommitAsync();
            await CacheAllUsersAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<User>>(CacherUserKey));
        }

        public Task<User> GetByIdAsync(int id)
        {
            var user = _memoryCache.Get<List<User>>(CacherUserKey).FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                throw new NotFoundException($"{typeof(User).Name} ({id}) not found");
            }

            return Task.FromResult(user);
        }

        public  Task<CustomResponseDto<List<UserWithCategoryDto>>> GetUsersWithCategory()
        {
            var users =  _memoryCache.Get<IEnumerable<User>>(CacherUserKey);

            var usersWithCategoryDto = _mapper.Map<List<UserWithCategoryDto>>(users);

            return Task.FromResult( CustomResponseDto<List<UserWithCategoryDto>>.Success(200,usersWithCategoryDto));

        }

        public async Task RemoveAsync(User entity)
        {
            _userRepository.Remove(entity);
            await _unitofWork.CommitAsync();
            await CacheAllUsersAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<User> entities)
        {
            _userRepository.RemoveRange(entities);
            await _unitofWork.CommitAsync();
            await CacheAllUsersAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _userRepository.Update(entity);
            await _unitofWork.CommitAsync();
            await CacheAllUsersAsync();
        }

        public IQueryable<User> Where(Expression<Func<User, bool>> expression)
        {
            return _memoryCache.Get<List<User>>(CacherUserKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllUsersAsync()
        {
            _memoryCache.Set(CacherUserKey, await _userRepository.GetAll().ToListAsync());
        }
    }
}

﻿using Ebebul.Core.DTOs;
using Ebebul.Core.Entity;
using Ebebul.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ebebul.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        public readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idvalue = context.ActionArguments.Values.FirstOrDefault();

            if (idvalue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idvalue;
            var anyEntity = await _service.AnyAsync(x=>x.Id == id);

            if(anyEntity)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));
            
        }
    }

}

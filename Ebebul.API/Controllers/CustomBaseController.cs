using Ebebul.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ebebul.API.Controllers
{
    
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        //Eğer NoAction yazmazsak bir endpoint algılar.
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            return new ObjectResult(response)
            {

                StatusCode = response.StatusCode
            };
        }
    }
}

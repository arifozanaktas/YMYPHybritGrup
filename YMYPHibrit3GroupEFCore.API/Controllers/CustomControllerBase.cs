using System.Net;
using Microsoft.AspNetCore.Mvc;
using YMYPHibrit3GroupEFCore.API.Models.Services;

namespace YMYPHibrit3GroupEFCore.API.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult CreateObjectResult<T>(ServiceResult<T> serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)serviceResult.Status
                };
            }

            return new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };
        }

        [NonAction]
        public IActionResult CreateObjectResult(ServiceResult serviceResult)
        {
            if (serviceResult.Status == HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = (int)serviceResult.Status
                };
            }

            return new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };
        }
    }
}
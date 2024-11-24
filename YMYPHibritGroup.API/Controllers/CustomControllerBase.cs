using Microsoft.AspNetCore.Mvc;
using System.Net;
using YMYPHibrit3Group.API.Model.Services;

namespace YMYPHibrit3Group.API.Controllers
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
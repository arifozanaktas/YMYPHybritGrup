using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YMYPHibrit3Group.API.Model.Services;

namespace YMYPHibrit3Group.API.Filters
{
    public class MyExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Ciddi bir hata var :{context.Exception.Message}");

            context.ExceptionHandled = true;

            var serviceResult =
                ServiceResult.Failure("İstenmeyen bir durum meydana geldi. Lütfen daha sonra tekrar deneyiniz.",
                    HttpStatusCode.InternalServerError);


            context.Result = new ObjectResult(serviceResult)
            {
                StatusCode = (int)serviceResult.Status
            };
        }
    }
}
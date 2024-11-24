using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YMYPHibrit3Group.API.Model.Services;

namespace YMYPHibrit3Group.API.Filters
{
    public class MyResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("OnResultExecuting çalıştı");
            context.HttpContext.Response.Headers.Add("MyResultFilter", "OnResultExecuting");


            var result = context.Result as ObjectResult;

            var data = result.Value;

            var newResult = new
            {
                Data = data,
                Version = "1.0"
            };

            context.Result = new ObjectResult(newResult) { StatusCode = result.StatusCode };
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            var result = context.Result as ObjectResult;


            var data = result.Value;


            Console.WriteLine("OnResultExecuted çalıştı");
        }
    }
}
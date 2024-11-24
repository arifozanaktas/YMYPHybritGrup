using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YMYPHibrit3Group.API.Model.Services;
using YMYPHibrit3Group.API.Model.Services.Dto;

namespace YMYPHibrit3Group.API.Filters
{
    public class MyResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("OnResourceExecuting çalıştı");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var objectResult = context.Result as ObjectResult;


            var products = objectResult.Value as ServiceResult<List<ProductDto>>;
            //var product = products.Data.First();
            //context.Result = new ObjectResult(product);
            Console.WriteLine("OnResourceExecuted çalıştı");
        }
    }
}
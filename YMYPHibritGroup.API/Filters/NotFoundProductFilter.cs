using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using YMYPHibrit3Group.API.Model.Repositories;
using YMYPHibrit3Group.API.Model.Services;
using YMYPHibrit3Group.API.Model.Services.Dto;

namespace YMYPHibrit3Group.API.Filters
{
    public class NotFoundProductFilter : Attribute, IActionFilter
    {
        private IProductRepository _productRepository; // field

        public NotFoundProductFilter(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Fast Fil
            //Guard clauses

            var methodType = context.HttpContext.Request.Method;

            int? id = null;
            var message = string.Empty;

            if (methodType == "PUT")
            {
                var updateProductRequest = context.ActionArguments.Values.First() as UpdateProductRequest;


                if (updateProductRequest is not null)
                {
                    id = updateProductRequest.Id;
                    message = "Güncellemeye çalıştığınız ürün bulunamadı";
                }
            }

            if (methodType == "DELETE")
            {
                var idAsObject = context.ActionArguments.Values.FirstOrDefault();


                if (idAsObject is not null)
                {
                    if (int.TryParse(idAsObject.ToString(), out int idValue) == true)
                    {
                        id = idValue;

                        message = "Silmeye çalıştığınız ürün bulunamadı";
                    }
                }
            }


            if (id.HasValue)
            {
                var hasProduct = _productRepository.Get(id.Value);


                if (hasProduct is null)
                {
                    var serviceResult = ServiceResult.Failure(message);


                    context.Result = new NotFoundObjectResult(serviceResult);
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
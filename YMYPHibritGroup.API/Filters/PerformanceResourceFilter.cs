using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace YMYPHibrit3Group.API.Filters
{
    public class PerformanceResourceFilter : Attribute, IResourceFilter
    {
        private Stopwatch _stopwatch;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;


            var descriptor = context?.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null)
            {
                var actionName = descriptor.ActionName;
                var ctrlName = descriptor.ControllerName;

                Console.WriteLine($"Request çalışma süresi({ctrlName}- {actionName}) :{elapsedMilliseconds} ms");
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc.Filters;

namespace MyStore.API.Annotations
{
    namespace MyStore.API.Annotations
    {
        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class EndpointInformationAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var controller = context.RouteData.Values["controller"];
            }

            public override void OnActionExecuted(ActionExecutedContext context)
            {

            }
        }
    }
}

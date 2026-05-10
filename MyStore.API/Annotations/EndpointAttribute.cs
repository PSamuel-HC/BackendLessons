using Microsoft.AspNetCore.Mvc.Filters;

namespace MyStore.API.Annotations
{
    public class EndpointAttribute : ActionFilterAttribute
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

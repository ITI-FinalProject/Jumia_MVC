using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UseScaffold.Custom_Filter
{
    public class HandleErrorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.ExceptionHandled = true;
                context.Result = new ViewResult() { ViewName = "HandelError" };
            }
            base.OnActionExecuted(context);
        }
    }
}

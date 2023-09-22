using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

public class NotFoundActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var controllerName = context.RouteData.Values["controller"].ToString();
        var actionName = context.RouteData.Values["action"].ToString();

        var controllerType = context.Controller.GetType();
        var actionMethod = controllerType.GetMethod(actionName);

        if (actionMethod == null)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary
            {
                {"controller", "TrangChu"},
                {"action", "Error404"}
            });
        }
    }
}

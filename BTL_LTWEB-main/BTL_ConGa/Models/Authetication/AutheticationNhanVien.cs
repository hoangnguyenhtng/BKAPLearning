using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BTL_ConGa.Models.Authetication
{
    public class AutheticationNhanVien : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("LoaiTaiKhoan") != "LTK01")
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "Controller", "TrangChu" } , { "Action", "Error404" }
                    });
            }
        }
    }
}

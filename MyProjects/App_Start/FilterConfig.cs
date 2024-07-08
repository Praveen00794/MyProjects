using System.Web;
using System.Web.Mvc;

namespace MyProjects
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
    public class sessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(HttpContext.Current.Session["UserName"]==null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}

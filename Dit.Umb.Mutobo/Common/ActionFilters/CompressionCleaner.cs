using System.Web.Mvc;
using Dit.Umb.Mutobo.Common.Classes;

namespace Dit.Umb.Mutobo.Common.ActionFilters
{
    public class CompressionCleaner : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            var response = filterContext.HttpContext.Response;

            if (response.ContentType == "text/html")
            {
                response.Filter = new MyCustomStream(filterContext.HttpContext.Response.Filter);
            }

            base.OnActionExecuted(filterContext);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Common.Classes;

namespace Dit.Umb.ToolBox.Common.ActionFilters
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

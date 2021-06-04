using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Dit.Umb.Mutobo.Common.ActionFilters
{
    public class LanguageRedirector : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["redirected"] == null)
            {
                var urlPrefix = string.Empty;
                CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                var languages = Current.Services.LocalizationService.GetAllLanguages().ToList();

                if (HttpContext.Current.Request.UserLanguages != null)
                {
                    foreach (var userLanguage in HttpContext.Current.Request.UserLanguages)
                    {
                        if (languages.Any(l => l.CultureInfo.Name == userLanguage))
                        {
                            var lang = languages.FirstOrDefault(l =>
                                l.CultureInfo.Name == userLanguage);

                            if (lang != null
                                && !lang.IsDefault)
                            {
                                HttpContext.Current.Session.Add("redirected", true);
                                var url = Current.UmbracoHelper.Content(Current.UmbracoHelper.AssignedContentItem.Id)
                                    .Url(lang.CultureInfo.Name, UrlMode.Absolute);
                                HttpContext.Current.Response.Redirect(url);

                            }
                        }
                    }
                }
            }
        }
    }
}

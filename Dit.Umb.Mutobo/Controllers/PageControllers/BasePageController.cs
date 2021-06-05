using System.Linq;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Common.ActionFilters;
using Dit.Umb.Mutobo.Common.Exceptions;
using Dit.Umb.Mutobo.Configuration;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.Mvc;

namespace Dit.Umb.Mutobo.Controllers.PageControllers
{
    [CompressionCleaner]
    [LanguageRedirector]
    public class BasePageController : RenderMvcController
    {
        protected readonly IPageLayoutService _pageLayoutService;
        protected readonly IThemeService _themeService;


  

        public BasePageController()
        {
            _themeService = (IThemeService) DependencyResolver.Current.GetService(typeof(IThemeService));
            _pageLayoutService = (IPageLayoutService)DependencyResolver.Current.GetService(typeof(IPageLayoutService));
        }



        public ActionResult Index<T>(BasePage basePage) where T : BasePage
        {

            var currentNode = Current.UmbracoHelper.AssignedContentItem;
            var redirectLink = currentNode.Value<Umbraco.Web.Models.Link>(DocumentTypes.BasePage.Fields.RedirectLink);

            if (!string.IsNullOrEmpty(redirectLink?.Url))
            {
                var url = redirectLink.Url.ToLower();
                if (!url.StartsWith("http"))
                    url = url.Insert(0, "http://");

                System.Web.HttpContext.Current.Response.Redirect(url);
            }

            try
            {
                basePage.HeaderConfiguration = _pageLayoutService.GetHeaderConfiguration(CurrentPage);
                basePage.FooterConfiguration = _pageLayoutService.GetFooterConfiguration(CurrentPage);
                basePage.FooterConfiguration.HomePageLogo = basePage.HeaderConfiguration.Logo;
                //basePage.Theme = _themeService.GetTheme(basePage.Content);

                



            }
            catch(AppSettingsException e)
            {
                Logger.Error(this.GetType(),e, $"{AppConstants.LoggingPrefix} {e.Message}");
                throw e;
            }
          



            return base.Index(basePage as T);
        }
    }
}

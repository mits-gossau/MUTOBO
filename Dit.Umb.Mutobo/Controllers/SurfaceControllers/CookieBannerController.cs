using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Web.Mvc;

namespace Dit.Umb.Mutobo.Controllers.SurfaceControllers
{
    public class CookieBannerController : SurfaceController
    {
        private readonly IConfigurationService _configurationService;


        public CookieBannerController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }


        public ActionResult Index()
        {
            return View("~/Views/Partials/CookieBanner.cshtml", new CookieBannerModel()
            {
                ApiKey = _configurationService.GetAppSettingValue("Classics.CookieBanner.APIKey"),
                Theme = _configurationService.GetAppSettingValue("Classics.CookieBanner.Theme"),
                Environment = _configurationService.GetAppSettingValue("Classics.CookieBanner.Environment")
            });
        }
    }
}
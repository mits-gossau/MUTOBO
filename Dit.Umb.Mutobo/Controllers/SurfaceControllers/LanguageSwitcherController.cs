using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Dit.Umb.ToolBox.Controllers.SurfaceControllers
{
    public class LanguageSwitcherController : SurfaceController
    {
        private readonly ILocalizationService _localizationService;


        public LanguageSwitcherController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }



        // GET: LanguageSwitcher
        public ActionResult Index(IEnumerable<PictureLink> pictureLinks = null)
        {

            var languages = _localizationService.GetAllLanguages()
                .Where(l => l.CultureInfo.TwoLetterISOLanguageName != CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
                .Select(l => new Language()
            {
                ISO = l.IsoCode,
                Name = l.CultureInfo.NativeName.Split(' ')[0].ToUpperInvariant(),
                Url = Umbraco.Content(CurrentPage.Id).Url(l.IsoCode, UrlMode.Absolute),
                CultureName = l.CultureInfo.Name

            });

            return View("~/Views/Partials/LanguageSwitcher.cshtml", new LanguageSwitcherModel()
            {
                Languages = languages

            });
        }
    }
}
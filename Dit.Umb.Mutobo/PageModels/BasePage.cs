using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Link = Umbraco.Web.Models.Link;

namespace Dit.Umb.Mutobo.PageModels
{
    public class BasePage : ContentModel
    {
        public Slogan GlobalSlogan { get; set; }
        public IHeaderConfiguration HeaderConfiguration { get; set; }
        public IFooterConfiguration FooterConfiguration { get; set; }
        public string PageTitle => Content.Value<string>(DocumentTypes.BasePage.Fields.PageTitle);

        public bool HideFromNavigation => Content.Value<bool>(DocumentTypes.BasePage.Fields.HideFromNavigation);

        public bool NotClickable => Content.Value<bool>(DocumentTypes.BasePage.Fields.NotClickable);

        public Link RedirectLink => Content.Value<Link>(DocumentTypes.BasePage.Fields.RedirectLink);

        public string MetaTitle => Content.Value<string>(DocumentTypes.BasePage.Fields.MetaTitle);
        public string MetaDescription => Content.Value<string>(DocumentTypes.BasePage.Fields.MetaDescription);
        public string MetaKeywords => Content.Value<string>(DocumentTypes.BasePage.Fields.MetaKeywords);
        public bool ExcludeFromXMLSitemap => Content.Value<bool>(DocumentTypes.BasePage.Fields.ExcludeFromXMLSitemap);
        public string SearchEngineFrequency => Content.HasValue(DocumentTypes.BasePage.Fields.SearchEngineFrequency) ? Content.Value<string>(DocumentTypes.BasePage.Fields.SearchEngineFrequency) : string.Empty;
        public string SearchEngineRelativePriority => Content.HasValue(DocumentTypes.BasePage.Fields.SearchEngineRelativePriority) ? Content.Value<string>(DocumentTypes.BasePage.Fields.SearchEngineRelativePriority) : string.Empty;
        public string GoogleAnalyticsKey => Content.HasValue(DocumentTypes.BasePage.Fields.GoogleAnalyticsKey)
            ? Content.Value<string>(DocumentTypes.BasePage.Fields.GoogleAnalyticsKey)
            : string.Empty;
        public ITheme Theme { get; set; }
        public bool ExcludeFromSearch => Content.Value<bool>(DocumentTypes.BasePage.Fields.ExcludeFromSearch);


        public BasePage(IPublishedContent content) : base(content)
        {
            
        }
    }
}

using System.Collections.Generic;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Language = Dit.Umb.Mutobo.PoCo.Language;
using Link = Umbraco.Web.Models.Link;


namespace Dit.Umb.Mutobo.Configuration
{
    public class HeaderConfiguration : PublishedElementModel, IHeaderConfiguration
    {

        public Slogan GlobalSlogan { get; set; }
        public IEnumerable<NavItem> NavigationItems { get; set; }

        public Image Logo { get; set; }

        public Link LogoUrl => this.Value<Umbraco.Web.Models.Link>(DocumentTypes.Configuration.Link);

        public IEnumerable<Language> Languages { get; set; }

        public Image StageImage { get; set; }

        public HeaderConfiguration(IPublishedElement content) : base(content)
        {



        }
    }
}

using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Interfaces;
using Dit.Umb.ToolBox.Models.PoCo;
using Microsoft.Ajax.Utilities;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Language = Dit.Umb.ToolBox.Models.PoCo.Language;
using Link = Umbraco.Web.Models.Link;


namespace Dit.Umb.ToolBox.Models.Configuration
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

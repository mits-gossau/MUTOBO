using System.Collections.Generic;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Link = Umbraco.Web.Models.Link;


namespace Dit.Umb.Mutobo.Configuration
{
    public class EmptyHeaderConfiguration : IHeaderConfiguration
    {
        public Slogan GlobalSlogan { get; set; }
        public IEnumerable<NavItem> NavigationItems { get; set; }
        public Image Logo { get; set; }
        public Link LogoUrl { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public Image StageImage { get; set; }
    }
}

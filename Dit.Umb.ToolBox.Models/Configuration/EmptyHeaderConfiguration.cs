using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Interfaces;
using Dit.Umb.ToolBox.Models.PoCo;
using Link = Umbraco.Web.Models.Link;


namespace Dit.Umb.ToolBox.Models.Configuration
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

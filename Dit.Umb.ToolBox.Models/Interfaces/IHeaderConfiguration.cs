using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using Link = Umbraco.Web.Models.Link;


namespace Dit.Umb.ToolBox.Models.Interfaces
{
    public interface IHeaderConfiguration
    {
        Slogan GlobalSlogan { get;  }
        IEnumerable<NavItem> NavigationItems { get;  }

        Image Logo { get;  }

        Link LogoUrl { get;  }


        IEnumerable<Language> Languages { get;  }

        Image StageImage { get;  }
    }
}
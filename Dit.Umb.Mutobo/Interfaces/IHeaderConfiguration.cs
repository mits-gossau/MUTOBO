using System.Collections.Generic;
using Dit.Umb.Mutobo.PoCo;
using Link = Umbraco.Web.Models.Link;


namespace Dit.Umb.Mutobo.Interfaces
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
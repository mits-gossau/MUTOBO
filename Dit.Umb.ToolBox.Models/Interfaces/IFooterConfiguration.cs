using System;
using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;

namespace Dit.Umb.ToolBox.Models.Interfaces
{
    public interface IFooterConfiguration
    {
         IEnumerable<FooterNavBlock> FooterNavBlocks { get;  }

         IEnumerable<Umbraco.Web.Models.Link> FooterLinks { get;  }

         IEnumerable<FooterContactArea> FooterContactBlock { get;  }

         IEnumerable<Language> Languages { get;  }


         IEnumerable<PictureLink> PictureLinks { get;  }

        Image HomePageLogo { get; set; }

        string Copyright { get;  }

        IEnumerable<Umbraco.Web.Models.Link> BlockLinks { get;  }


        string Theme { get;  }
    }
}
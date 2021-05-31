using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Modules;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models.ContentEditing;

namespace Dit.Umb.ToolBox.Models.PageModels
{
    public class HomePage : BasePage
    {

        public IEnumerable<MutoboContentModule> Modules { get; set; }




        public HomePage(IPublishedContent content) : base(content)
        {



        }
    }
}

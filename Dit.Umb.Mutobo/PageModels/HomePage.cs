using System.Collections.Generic;
using Dit.Umb.Mutobo.Modules;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.PageModels
{
    public class HomePage : BasePage
    {

        public IEnumerable<MutoboContentModule> Modules { get; set; }




        public HomePage(IPublishedContent content) : base(content)
        {



        }
    }
}

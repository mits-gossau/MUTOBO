using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;

namespace Sss.Waldlaeufer.PageModels
{
    public class WoodHomePage : HomePage
    {
        public WoodHomePage(IPublishedContent content) : base(content)
        {
        }
    }
}

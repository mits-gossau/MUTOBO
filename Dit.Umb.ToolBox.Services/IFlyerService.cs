using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Modules;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IFlyerService
    {
        IEnumerable<Flyer> GetFlyer(IPublishedContent node, bool firstPic = false);
    }
}

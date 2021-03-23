using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class DocumentComponent : MutoboContentModule
    {
        public DocumentComponent(IPublishedElement content) : base(content)
        {
        }
    }
}

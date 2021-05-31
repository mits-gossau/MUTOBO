using System.Collections.Generic;
using System.Linq;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.Modules
{
    public class BlogModule : MutoboContentModule
    {
        public IEnumerable<ArticlePage> BlogEntries => this.HasValue(DocumentTypes.BlogModule.Fields.ParentPage)
            ? this.Value<IPublishedContent>(DocumentTypes.BlogModule.Fields.ParentPage).Children.OrderByDescending(c => c.CreateDate)
                .Select(c => new ArticlePage(c))
            : null;

        public BlogModule(IPublishedElement content) : base(content)
        {
        }
    }
}

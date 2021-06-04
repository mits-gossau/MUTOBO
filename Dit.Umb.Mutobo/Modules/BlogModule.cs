using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class BlogModule : MutoboContentModule, IModule
    {
        public IEnumerable<ArticlePage> BlogEntries => this.HasValue(DocumentTypes.BlogModule.Fields.ParentPage)
            ? this.Value<IPublishedContent>(DocumentTypes.BlogModule.Fields.ParentPage).Children.OrderByDescending(c => c.CreateDate)
                .Select(c => new ArticlePage(c))
            : null;

        public BlogModule(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append(helper.Partial("~/Views/Partials/BlogList.cshtml", this));
            return new MvcHtmlString(bld.ToString());
        }
    }
}

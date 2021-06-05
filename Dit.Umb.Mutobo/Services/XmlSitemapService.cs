using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Services
{
    public class XmlSitemapService : BaseService, IXmlSitemapServicecs
    {

		


        public IEnumerable<BasePage> GetXmlSitemap(IPublishedContent model)
        {
            var homePage = Helper.AssignedContentItem.AncestorsOrSelf().FirstOrDefault(c =>
                c.ContentType.Alias == DocumentTypes.HomePage.Alias);
            
            
            return from n in GenerateSiteMapNodes(homePage)
				   where n.ContentType.CompositionAliases.Contains(DocumentTypes.BasePage.Alias)
				   select new BasePage(n);
        }

		private IEnumerable<IPublishedContent> GenerateSiteMapNodes(IPublishedContent content)
		{
			yield return content;
			if (content.Children == null)
			{
				yield break;
			}
			foreach (IPublishedContent child in content.Children)
			{
				foreach (IPublishedContent item in GenerateSiteMapNodes(child))
				{
					yield return item;
				}
			}
		}

		private string EnsureUrlStartsWithDomain(string url)
		{
			if (url.StartsWith("http"))
			{
				return url;
			}
			return string.Concat("https://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + "/", url);
		}
	}
}

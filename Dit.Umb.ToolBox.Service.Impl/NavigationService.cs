using System.Collections.Generic;
using System.Linq;
using Dit.Umb.ToolBox.Common.Exceptions;
using Dit.Umb.ToolBox.Common.Extensions;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class NavigationService : BaseService, INavigationService
    {



        /// <summary>
        /// Return all pages bases on the  documentType "basePage" mapped
        /// on an IEnumerable of NavItem objects. All pages with a HideONNavigation flag
        /// will be filtered out of the result set.
        /// </summary>
        /// <returns>IEnumarable of NavItem</returns>
        public IEnumerable<NavItem> GetNavigation()
        {
            var result = new List<NavItem>();


            var homePage = DetermineHomeNode();

            



            if (homePage == null)
                throw new NavigationException("No Node found");


            if (homePage.Children != null && homePage.Children.Any())
            {
                foreach (var childNode in homePage.Children.Where(n => n.IsDocumentType(DocumentTypes.BasePage.Alias, true)))
                {
                    if (!childNode.Value<bool>(DocumentTypes.BasePage.Fields.HideFromNavigation))
                    {
                        result.Add(new NavItem()
                        {
                            Title = childNode.Name,
                            Url = childNode.Value<bool>(DocumentTypes.BasePage.Fields.NotClickable) ? "#" : childNode.GetDitUrl(),
                            NewWindow = childNode.GetOpenInNewWindowFlag(),
                            Children = childNode.Children
                                .Where(n => n.IsDocumentType(DocumentTypes.BasePage.Alias, true))
                                .Select(c => new BasePage(c))
                                .Where(bp => !bp.HideFromNavigation)
                                .Select(bp => new NavItem()
                                {
                                    Title = bp.Content.Name,
                                    Url = bp.Content.Value<bool>(DocumentTypes.BasePage.Fields.NotClickable) ? "#" : bp.Content.GetDitUrl(),
                                    NewWindow = bp.Content.GetOpenInNewWindowFlag()
                                })
                        });
                    }

                }
            }

            

            return result;
        }


        private IPublishedContent DetermineHomeNode()
        {
            var node = Helper.AssignedContentItem;

            while (node.Parent != null)
            {
                node = node.Parent;

            } 

            return node;
        }
    }
}

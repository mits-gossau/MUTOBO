using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dit.Umb.Mutobo.Common;
using Dit.Umb.Mutobo.Configuration;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Dit.Umb.Mutobo.Services
{
    public class PageLayoutService : BaseService, IPageLayoutService
    {
        private readonly INavigationService _navigationService;
        private readonly ILocalizationService _localizationService;
        private readonly IImageService _imageService;
        private readonly IPictureLinkService _pictureLinkService;


        public PageLayoutService(
            INavigationService navigationService,
            ILocalizationService localizationService,
            IImageService imageService,
            IPictureLinkService pictureLinkService)
        {
            _navigationService = navigationService;
            _localizationService = localizationService;
            _imageService = imageService;
            _pictureLinkService = pictureLinkService;
        }

        /// <summary>
        /// Returns the first found IHeaderConfiguration recursively upwards 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public IHeaderConfiguration GetHeaderConfiguration(IPublishedContent content = null)
        {
            HeaderConfiguration headerConfig = null;
            var branch = content?.AncestorsOrSelf().ToList();
            var index = 0;

            if (branch != null)
            {
                do
                {
                    headerConfig = branch[index].HasValue(DocumentTypes.BasePage.Fields.HeaderConfiguration)
                        ? new HeaderConfiguration(branch[index].Value<IEnumerable<IPublishedElement>>(DocumentTypes.BasePage.Fields.HeaderConfiguration).FirstOrDefault()) : null;
                    index++;

                } while (index < branch.Count() && headerConfig == null);
            }

            if (headerConfig != null)
            {
                return new HeaderConfiguration(headerConfig)
                {
                    NavigationItems = _navigationService.GetNavigation(),
                    Logo = _imageService.GetImage(headerConfig.Value<IPublishedContent>(DocumentTypes.Configuration.Logo), height: 100),
                    Languages = _localizationService.GetAllLanguages()
                        .Where(l => !Equals(l.CultureInfo, CultureInfo.CurrentCulture))
                        .Select(a => new Language()
                        {
                            Name = a.CultureInfo.NativeName.Split(' ')[0],
                            ISO = a.CultureInfo.TwoLetterISOLanguageName
                        }),
                    GlobalSlogan = GetGlobalSlogan()

                };
            }
            else
            {
                return new EmptyHeaderConfiguration();
            }
        }

        /// <summary>
        /// Returns the first found IFooterConfiguration recursively upwards 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public IFooterConfiguration GetFooterConfiguration(IPublishedContent content = null)
        {
            FooterConfiguration footerConfig = null;
            var branch = content?.AncestorsOrSelf().ToList();
            var index = 0;

            if (branch != null)
            {
                do
                {
                    footerConfig = branch[index].HasValue(DocumentTypes.BasePage.Fields.FooterConfiguration)
                        ? new FooterConfiguration(branch[index].Value<IEnumerable<IPublishedElement>>(DocumentTypes.BasePage.Fields.FooterConfiguration).FirstOrDefault()) : null;
                    index++;
                } while (index < branch.Count() && footerConfig == null);
            }


            if (footerConfig != null)
            {
                var nodes = footerConfig.HasValue(DocumentTypes.FooterConfiguration.Fields.NavigationArea) ?
    footerConfig.Value<IEnumerable<IPublishedElement>>(DocumentTypes.FooterConfiguration.Fields.NavigationArea)
    : new List<IPublishedElement>();
                var linkBlocks = new List<FooterNavBlock>();

                foreach (var node in nodes)
                {
                    var contentNode = Current.UmbracoHelper.Content(node.Value<IPublishedContent>(DocumentTypes.FooterNavBlock.StartNode).Id);
                    linkBlocks.Add(GetFooterLinkBlock(contentNode));
                }

                var footerLinks = footerConfig.Value<IEnumerable<Umbraco.Web.Models.Link>>(DocumentTypes.FooterConfiguration.Fields.Links) ??
                                  new List<Umbraco.Web.Models.Link>();
                var contactNode = footerConfig.HasValue(DocumentTypes.FooterConfiguration.Fields.ContactArea) ?
                    footerConfig.Value<IEnumerable<IPublishedElement>>(DocumentTypes.FooterConfiguration.Fields.ContactArea)
                        .Select(e => new FooterContactArea(e))
                    : new List<FooterContactArea>();
                var langs = _localizationService.GetAllLanguages().ToList();
                var headerConfiguration = GetHeaderConfiguration(content);
                return new FooterConfiguration(footerConfig)
                {
                    FooterNavBlocks = linkBlocks,
                    FooterContactBlock = contactNode,
                    Languages = _localizationService.GetAllLanguages()
                        .Where(l => !Equals(l.CultureInfo, CultureInfo.CurrentCulture))
                        .Select(a => new Language()
                        {
                            Name = a.CultureInfo.NativeName.Split(' ')[0],
                            ISO = a.CultureInfo.TwoLetterISOLanguageName,
                            CultureName = a.CultureInfo.Name
                        }),
                    PictureLinks = footerConfig.HasValue(DocumentTypes.FooterConfiguration.Fields.PictureLinks) ?
                        _pictureLinkService.GetPictureLinks(footerConfig.Value<IEnumerable<IPublishedElement>>(DocumentTypes.FooterConfiguration.Fields.PictureLinks)) :
                        new List<PictureLink>(),
                    HomePageLogo = headerConfiguration?.Logo
                };
            }

            return new EmptyFooterConfiguration();
        }

        private Slogan GetGlobalSlogan()
        {
            var homePage = Current.UmbracoHelper
                .ContentAtRoot()
                .FirstOrDefault(c => c.ContentType.Alias == DocumentTypes.HomePage.Alias);

            if (homePage == null)
                return new Slogan()
                {
                    SubTitle = String.Empty,
                    Title = String.Empty
                };

            return new Slogan()
            {
                SubTitle = homePage.HasValue(DocumentTypes.HomePage.Fields.SloganSubTitle) ?
                    homePage.Value<string>(DocumentTypes.HomePage.Fields.SloganSubTitle) : string.Empty,
                Title = homePage.HasValue(DocumentTypes.HomePage.Fields.SloganTitle) ?
                    homePage.Value<string>(DocumentTypes.HomePage.Fields.SloganTitle) : string.Empty
            };

        }

        private FooterNavBlock GetFooterLinkBlock(IPublishedContent parentNode)
        {

            return new FooterNavBlock()
            {
                Title = new Link() { Text = parentNode.Name, Url = parentNode.Url() },
                Children = parentNode.Children.Select(c => new Link()
                {
                    Url = c.GetDitUrl(),
                    Text = c.Name,
                    Target = c.GetLinkTarget()

                })
            };
        }
    }
}


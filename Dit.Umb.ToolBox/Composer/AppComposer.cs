using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dit.Umb.ToolBox.Components;
using Dit.Umb.ToolBox.Services.Impl;
using Dit.Umb.ToolBox.Services;
using MissingCode.Umbraco.HtmlMinifier;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;

namespace Dit.Umb.ToolBox.Composer
{
    public class AppComposer : IUserComposer
    {


        /// <summary>
        /// Composer to compose the web page
        /// </summary>
        /// <param name="composition"></param>
        public void Compose(Composition composition)
        {
            RegisterServices(composition);
  
            AddComponents(composition);
            

        }

        /// <summary>
        /// Method to add custom implemented components which implements IComponent
        /// </summary>
        private void AddComponents(Composition composition)
        {
            composition.Components().Append<ApiConfigurationComponent>();
            composition.Components().Append<SearchConfigurationComponent>();
            composition.Components().Append<HtmlMinifierComponent>();
            //composition.Components().Append<CustomDropDownPopulateComponent>();

        }


        /// <summary>
        /// Method to register all custom implemented services
        /// </summary>
        /// <param name="composition"></param>
        private void RegisterServices(Composition composition)
        {
            composition.Register(typeof(INavigationService), typeof(NavigationService), Lifetime.Scope);
            composition.Register(typeof(IImageService), typeof(ImageService), Lifetime.Singleton);
            composition.Register(typeof(IScriptService), typeof(ScriptService), Lifetime.Singleton);
            composition.Register(typeof(IConfigurationService), typeof(ConfigurationService), Lifetime.Singleton);
            composition.Register(typeof(ISearchService), typeof(SearchService), Lifetime.Scope);
            composition.Register(typeof(ITeaserService), typeof(TeaserService), Lifetime.Scope);
            composition.Register(typeof(IXmlSitemapServicecs), typeof(XmlSitemapService), Lifetime.Scope);
            composition.Register(typeof(IFlyerService), typeof(FlyerService), Lifetime.Scope);
            composition.Register(typeof(IPageLayoutService), typeof(PageLayoutService), Lifetime.Scope);
          
            composition.Register(typeof(IPictureLinkService), typeof(PictureLinkService), Lifetime.Scope);
            composition.Register(typeof(IThemeService), typeof(ThemeService), Lifetime.Scope);
          
            composition.Register(typeof(IMutoboContentService), typeof(MutoboContentService), Lifetime.Singleton);
            composition.Register(typeof(IMailService), typeof(MailService), Lifetime.Singleton);
            composition.Register(typeof(IFormPageService), typeof(FormPageService), Lifetime.Singleton);
            composition.Register(typeof(IVideoService), typeof(VideoService), Lifetime.Singleton);
        }
    }
}
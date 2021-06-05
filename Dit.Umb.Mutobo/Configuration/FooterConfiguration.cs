using System;
using System.Collections.Generic;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Configuration
{
    public class FooterConfiguration : PublishedElementModel, IFooterConfiguration
    {
        public IEnumerable<FooterNavBlock> FooterNavBlocks { get; set; }

        public IEnumerable<Umbraco.Web.Models.Link> FooterLinks =>
            this.Value<IEnumerable<Umbraco.Web.Models.Link>>(DocumentTypes.FooterConfiguration.Fields.Links);

        public IEnumerable<FooterContactArea> FooterContactBlock { get; set; }

        public IEnumerable<Language> Languages { get; set; }


        public IEnumerable<PictureLink> PictureLinks { get; set; }

        public Image HomePageLogo { get; set; }

        public string Copyright => $"&copy; {DateTime.Today.Year} {this.Value<string>(DocumentTypes.FooterConfiguration.Fields.CopyRight)}" ;

        public IEnumerable<Umbraco.Web.Models.Link> BlockLinks => this.Value<IEnumerable<Umbraco.Web.Models.Link>>(DocumentTypes.FooterConfiguration.Fields.BlockLinks);


        public string Theme { get; set; }

        public FooterConfiguration(IPublishedElement content) : base(content)
        {
        }
    }
}

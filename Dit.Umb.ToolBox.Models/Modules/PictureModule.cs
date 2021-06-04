﻿using System.Text;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Interfaces;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.Modules
{
    public class PictureModule : MutoboContentModule, IModule
    {

        public Image Image { get; set; }

        public int? Height => this.HasValue(DocumentTypes.PictureModule.Fields.Height)
            ? this.Value<int?>(DocumentTypes.PictureModule.Fields.Height)
            : null;


        public int? Width => this.HasValue(DocumentTypes.PictureModule.Fields.Width)
            ? this.Value<int?>(DocumentTypes.PictureModule.Fields.Width)
            : null;



        public PictureModule(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append($"<div>{Image.RenderWcPictureTag(nameSpace: "picture-", width: $"{Image.Width}", height: $"{Image.Height}")}</div>");
            return new HtmlString(bld.ToString());
        }
    }
}

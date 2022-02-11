﻿using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Modules
{
    public class TwoColumnContainer : MutoboContentModule, IModule
    {
        public IEnumerable<IPublishedElement> Elements { get; set; }

        public TwoColumnContainer(IPublishedElement content) : base(content)
        {
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append(helper.Partial("~/Views/Partials/Modules/TwoColumnContainer.cshtml", this));
            return new MvcHtmlString(bld.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Enum;
using Dit.Umb.ToolBox.Models.PoCo;

namespace Dit.Umb.ToolBox.Mutobo
{

    /// <summary>
    /// This extension is highly urgent please render all MUTOTBO-Modules
    /// with this method 
    /// </summary>
    public static class ModuleRenderer
    {
        public static MvcHtmlString RenderModules(this HtmlHelper helper, IEnumerable<MutoboContentModule> modules)
        {
            var bld = new StringBuilder();

            foreach (var module in modules)
            {
                switch (module.ContentType.Alias)
                {
                    case DocumentTypes.Teaser.Alias:
                        var teaser = (module as Teaser);
                        switch (teaser?.RenderAs)
                        {
                            case EHighlightRendering.Gallery:
                                bld.Append(helper.Partial("~/Views/Partials/GalleryTeaser.cshtml", teaser));
                                break;
                            case EHighlightRendering.Teaser:
                                bld.Append(helper.Partial("~/Views/Partials/NestedTeaser.cshtml", teaser));
                                break;
                            default:
                                break;
                        }
                        break;
                    case DocumentTypes.Heading.Alias:
                            bld.Append($"<h2>{(module as Heading)?.Text.ToUpper()}</h2>");
                        break;
                    case DocumentTypes.VideoComponent.Alias:
                        if (module is VideoComponent videoComponent)
                            bld.Append(helper.Partial("~/Views/Partials/VideoComponent.cshtml", videoComponent));
                        break;
                    case DocumentTypes.Flyer.Alias:
                        if (module is Flyer flyer)
                            bld.Append(helper.Partial("~/Views/Partials/Flyer.cshtml", flyer));
                        break;
                    case DocumentTypes.RichTextComponent.Alias:
                        if (module is RichtextComponent richTextComponent)
                            bld.Append($"<div style=\"width: 100%;  text-align: center;\">{helper.Raw(richTextComponent.RichText)}</div>");
                        break;
     

                }
            }

            return new MvcHtmlString(bld.ToString());
        }
    }
}
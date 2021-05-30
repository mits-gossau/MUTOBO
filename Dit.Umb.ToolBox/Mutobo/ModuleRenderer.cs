using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.ToolBox.Models.Enum;
using Dit.Umb.ToolBox.Models.PoCo;
using Dit.Umb.ToolBox.Services;
using Umbraco.Web;
using DocumentTypes = Dit.Umb.ToolBox.Models.Constants.DocumentTypes;

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
                            case EHighlightRendering.Teaser:
                                bld.Append(helper.Partial("~/Views/Partials/NestedTeaser.cshtml", teaser));
                                break;
                            default:
                            case EHighlightRendering.Gallery:
                                bld.Append(helper.Partial("~/Views/Partials/GalleryTeaser.cshtml", teaser));
                                break;
                        }

                        if (teaser.SpacerAfterModule)
                        {
                            bld.Append("<div class=\"spacer\"></div>");
                        }

                        break;
                    case DocumentTypes.Heading.Alias:
                        if (module is Heading heading)
                        {
                            var anchor = $"id=\"{heading.NavigationAnchor}\""  ?? string.Empty;

                            switch (heading.RenderAs)
                            {
                                case EHeadingRenderType.Heading1:
                                    bld.Append($"<h1 {anchor}>{heading.Text.ToUpper()}</h1>");
                                    break;
                                case EHeadingRenderType.Heading2:
                                    bld.Append($"<h2 {anchor}>{heading.Text.ToUpper()}</h2>");
                                    break;
                                case EHeadingRenderType.Heading3:
                                    bld.Append($"<h3 {anchor}>{heading.Text.ToUpper()}</h3>");
                                    break;
                                case EHeadingRenderType.Heading4:
                                    bld.Append($"<h4 {anchor}>{heading.Text.ToUpper()}</h4>");
                                    break;
                                case EHeadingRenderType.Heading5:
                                    bld.Append($"<h5 {anchor}>{heading.Text.ToUpper()}</h5>");
                                    break;
                                case EHeadingRenderType.Heading6:
                                    bld.Append($"<h6 {anchor}>{heading.Text.ToUpper()}</h6>");
                                    break;
                            }
                        }
                        break;
                    case DocumentTypes.VideoComponent.Alias:
                        if (module is VideoComponent videoComponent)
                        {
                 
                            bld.Append(helper.Partial("~/Views/Partials/VideoComponent.cshtml", videoComponent));
                  
                            if (videoComponent.SpacerAfterModule)
                            {
                                bld.Append("<div class=\"spacer\"></div>");
                            }
                        }
                        break;
                    case DocumentTypes.Flyer.Alias:
                        if (module is Flyer flyer)
                        {
                            if (flyer.Timer > 0)
                            {
                                switch (flyer.Direction)
                                {
                                    case EDirection.Right:
                                        bld.Append(helper.Partial("~/Views/Partials/Flyer_right.cshtml",
                                            flyer));
                                        break;

                                    default:
                                    case EDirection.Left:
                                        bld.Append(helper.Partial("~/Views/Partials/Flyer_left.cshtml", flyer));
                                        break;
                                }
                            }
                            else
                            {
                                switch (flyer.Direction)
                                {
                                    case EDirection.Right:
                                        bld.Append(helper.Partial("~/Views/Partials/IntersectionFlyer_right.cshtml",
                                            flyer));
                                        break;

                                    default:
                                    case EDirection.Left:
                                        bld.Append(helper.Partial("~/Views/Partials/IntersectionFlyer_left.cshtml", flyer));
                                        break;
                                }

                            }
                        }
                        break;
                    case DocumentTypes.RichTextComponent.Alias:
                        if (module is RichtextComponent richTextComponent)
                        {
                            bld.Append($"<article>{helper.Raw(richTextComponent.RichText)}</article>");
                            if (richTextComponent.SpacerAfterModule)
                            {
                                bld.Append("<div class=\"spacer\"></div>");
                            }
                        }
                        break;
                    case DocumentTypes.SliderComponent.Alias:
                        if (module is SliderComponent sliderComponent)
                        {
                            bld.Append(helper.Partial("~/Views/Partials/Slider.cshtml", sliderComponent));
                            
                            if (sliderComponent.SpacerAfterModule)
                            {
                                bld.Append("<div class=\"spacer\"></div>");
                            }
                        }
                        break;
                    case DocumentTypes.Newsletter.Alias:
                        if (module is Newsletter newsletter)
                            bld.Append(helper.Partial("~/Views/Partials/Newsletter.cshtml", newsletter));
                        break;

                    case DocumentTypes.PictureModule.Alias:
                        if (module is PictureModule picture)
                        {
                            var imageService =
                                (IImageService) DependencyResolver.Current.GetService(typeof(IImageService));
                            var configurationService =
                                (IConfigurationService)DependencyResolver.Current.GetService(typeof(IConfigurationService));

                            var width = picture.Width;
                            var height = picture.Height;

                            if (picture.Image != null)
                            {
                                bld.Append(imageService.GetImage(picture.Image.ImageNode, width, height).RenderWcPictureTag(nameSpace: "picture-"));
                            }
                            
                          
                        }
                        break;
                    case DocumentTypes.BlogModule.Alias:
                        if (module is BlogModule blogModule)
                        {
                            bld.Append(helper.Partial("~/Views/Partials/BlogList.cshtml", blogModule));
                        }

                        break;

                }
            }
            return new MvcHtmlString(bld.ToString());
        }
    }
}
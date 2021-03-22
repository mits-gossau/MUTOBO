using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Dit.Umb.ToolBox.Models.Enum;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class Image
    {
        public IPublishedContent ImageNode { get; set; }
        public IEnumerable<ImageSource> Sources { get; set; }
        public string Alt { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Namespace { get; set; }



        public ImageSource DefaultSource => Sources?
            .FirstOrDefault(s => s.Size == EImageDimension.Default);


        public string GetSourcesAsJSON()
        {
            var serializer = new JsonSerializer();
            var result = JsonConvert.SerializeObject(Sources.Where(s => s.Size != EImageDimension.Default), new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new List<JsonConverter>()
                {
                    new StringEnumConverter()
                }
                
            });

            return HttpUtility.HtmlDecode(result).Replace("\"", "'");

        }

        public HtmlString RenderWcPictureTag(string width = null, string height = null)
        {
            if (height != null || width != null)
            {
                Height = height;
                Width = width;
            }


            var bld = new StringBuilder();

            bld.Append(
                $"<a-picture namespace=\"{Namespace}-\" defaultSource=\"{DefaultSource.Src}\" alt=\"{Alt}\" sources=\"{GetSourcesAsJSON()}\">");

            if (Width != null || Height != null)
            {
                bld.Append("<style>:host{");

                if (Height != null && Width == null)
                    bld.Append($"--{Namespace}-height:{Height};");

                if (Width != null)
                {
                    if (Height == null)
                    {
                        bld.Append($"--{Namespace}-width:{Width};");
                    }
                }
                else
                {
                    bld.Append($"--{Namespace}-img-width:auto;");
                }

                bld.Append("}</style>");
            }

            bld.Append($"</a-picture>");
            return new HtmlString(bld.ToString());
        }
    }
}

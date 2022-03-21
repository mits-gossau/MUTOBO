using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class ImageHotspotContainer : PublishedElementModel
    {
        public ImageHotspot Hotspot { get; set; }
        
        public decimal X { get; set; }

        public decimal Y { get; set; }

        public EImageHotspotPlace Place => this.HasValue(DocumentTypes.ImageHotspotContainer.Fields.Place)
            ? this.Value<EImageHotspotPlace>(DocumentTypes.ImageHotspotContainer.Fields.Place)
            : EImageHotspotPlace.Bottom;


        public ImageHotspotContainer(IPublishedElement content) : base(content)
        {
            if (this.Value("position") != null)
            {
                Hotspot position = JsonConvert.DeserializeObject<Hotspot>(this.Value("position").ToString());
                this.X = position.PercentX;
                this.Y = position.PercentY;
            }
        }

    }

}

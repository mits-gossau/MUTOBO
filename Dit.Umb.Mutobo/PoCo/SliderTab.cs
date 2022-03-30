using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class SliderTab : PublishedContentModel
    {
        public int DataId { get; set; }
        public string Title => this.HasValue(DocumentTypes.SliderTab.Fields.Title)
           ? this.Value<string>(DocumentTypes.SliderTab.Fields.Title)
           : string.Empty;

        public MutoboContentModule Media { get; set; }

        public IEnumerable<MutoboContentModule> Modules { get; set; }


        public string BackgroundColor => this.HasValue(DocumentTypes.SliderTab.Fields.BackgroundColor)
            ? this.Value<string>(DocumentTypes.SliderTab.Fields.BackgroundColor)
            : string.Empty;

        public Image BackgroundImg { get; set; }


        public SliderTab(IPublishedContent content) : base(content) { }
    }
}

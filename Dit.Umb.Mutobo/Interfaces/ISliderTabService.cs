using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ISliderTabService
    {
        IEnumerable<SliderTab> GetTabs(IPublishedElement content, string fieldName);
    }
}

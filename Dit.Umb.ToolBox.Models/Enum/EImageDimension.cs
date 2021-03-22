using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Dit.Umb.ToolBox.Models.Enum
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EImageDimension
    {
        
        Default,
        [EnumMember(Value = "small")]
        Small,
        [EnumMember(Value = "medium")]
        Medium,
        [EnumMember(Value = "large")]
        Large,
        [EnumMember(Value = "extra-large")]
        ExtraLarge
    }
}

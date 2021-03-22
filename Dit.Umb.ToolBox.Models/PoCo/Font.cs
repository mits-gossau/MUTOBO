using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class Font
    {

        public string Name { get; set; }
        public IEnumerable<FileInfo> Files { get; set; }
    }
}

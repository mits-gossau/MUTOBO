using System.Collections.Generic;
using System.IO;

namespace Dit.Umb.Mutobo.PoCo
{
    public class Font
    {

        public string Name { get; set; }
        public IEnumerable<FileInfo> Files { get; set; }
    }
}

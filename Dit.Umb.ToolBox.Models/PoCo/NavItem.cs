using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class NavItem
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public IEnumerable<NavItem> Children { get; set; }
        public bool NewWindow { get; set; }
        public bool NotClickable { get; set; }
        public bool IsSearchPage { get; set; }


    }
}

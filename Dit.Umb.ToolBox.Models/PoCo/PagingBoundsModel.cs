using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class PagingBoundsModel
    {
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public bool ShowFirstButton { get; set; }
        public bool ShowLastButton { get; set; }

        public PagingBoundsModel(int startPage, int endPage, bool showFirstButton, bool showLastButton)
        {
            StartPage = startPage;
            EndPage = endPage;
            ShowFirstButton = showFirstButton;
            ShowLastButton = showLastButton;
        }
    }
}

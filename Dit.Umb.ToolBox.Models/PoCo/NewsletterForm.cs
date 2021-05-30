using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class NewsletterForm
    {
        public bool? success = null;


        public string Anrede { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int Zip { get; set; }
        public string Place { get; set; }
        public string Email { get; set; }
        public bool Policy { get; set; }

        public string FuSb { get; set; }
    }
}

using System.Collections.Generic;

namespace Dit.Umb.Mutobo.PoCo
{
    public class FooterNavBlock
    {
        public Link Title { get; set; }
        public IEnumerable<Link> Children { get; set; }
    }
}

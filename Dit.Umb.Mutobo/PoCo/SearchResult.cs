using System.Collections.Generic;

namespace Dit.Umb.Mutobo.PoCo
{
    public class SearchResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public Image EmotionImage { get; set; }
        public string  Url { get; set; }
        public string UrlTitle { get; set; }
        public List<Document> Documents { get; set; }


        public SearchResult()
        {
            Documents = new List<Document>();
        }

    }
}

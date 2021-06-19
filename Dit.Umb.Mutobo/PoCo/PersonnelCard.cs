using Dit.Umb.Mutobo.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class PersonnelCard : Card
    {
        public string Lastname => this.HasValue(DocumentTypes.PersonnelCard.Fields.Lastname)
            ? this.Value<string>(DocumentTypes.PersonnelCard.Fields.Lastname)
            : null;
        public string Firstname => this.HasValue(DocumentTypes.PersonnelCard.Fields.Firstname)
            ? this.Value<string>(DocumentTypes.PersonnelCard.Fields.Firstname)
            : null;
        public string Function => this.HasValue(DocumentTypes.PersonnelCard.Fields.Function)
            ? this.Value<string>(DocumentTypes.PersonnelCard.Fields.Function)
            : null;

        public PersonnelCard(IPublishedElement content) : base(content)
        {
        }
    }
}

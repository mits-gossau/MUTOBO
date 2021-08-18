using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
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

        public string Description => this.HasValue(DocumentTypes.PersonnelCard.Fields.Description)
            ? this.Value<string>(DocumentTypes.PersonnelCard.Fields.Description)
            : null;


        public EPersonalCardDisplayType DisplayType => this.HasValue(DocumentTypes.PersonnelCard.Fields.DisplayType) && !string.IsNullOrEmpty(this.Value<string>(DocumentTypes.PersonnelCard.Fields.DisplayType)?.Trim())
            ? (EPersonalCardDisplayType) System.Enum.Parse(typeof(EPersonalCardDisplayType),
                this.Value<string>(DocumentTypes.PersonnelCard.Fields.DisplayType)) : EPersonalCardDisplayType.Compact;

        public bool IsMainPerson => this.Value<bool>(DocumentTypes.PersonnelCard.Fields.IsMainPerson);



        public PersonnelCard(IPublishedElement content) : base(content)
        {
        }
    }
}

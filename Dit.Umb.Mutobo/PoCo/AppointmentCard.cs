using System;
using Dit.Umb.Mutobo.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class AppointmentCard : Card
    {

        public DateTime Date => this.HasValue(DocumentTypes.AppointmentCard.Fields.Date)
            ? this.Value<DateTime>(DocumentTypes.AppointmentCard.Fields.Date)
            : DateTime.MinValue;

        public string Title => this.HasValue(DocumentTypes.AppointmentCard.Fields.Title)
            ? this.Value<string>(DocumentTypes.AppointmentCard.Fields.Title)
            : string.Empty;

        public string Description => this.HasValue(DocumentTypes.AppointmentCard.Fields.Description)
            ? this.Value<string>(DocumentTypes.AppointmentCard.Fields.Description)
            : string.Empty;


        public AppointmentCard(IPublishedElement content) : base(content)
        {
        }
    }
}

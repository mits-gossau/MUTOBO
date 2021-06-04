using Dit.Umb.Mutobo.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Configuration
{
    public class MailConfiguration : ContentModel
    {

        public string MailSubject => this.Content.HasValue(DocumentTypes.MailConfiguration.Fields.MailSubject)
            ? this.Content.Value<string>(DocumentTypes.MailConfiguration.Fields.MailSubject) : null; 
        public string MailBody => this.Content.HasValue(DocumentTypes.MailConfiguration.Fields.MailBody)
            ? this.Content.Value<string>(DocumentTypes.MailConfiguration.Fields.MailBody) : null;
        public string MailHeader => this.Content.HasValue(DocumentTypes.MailConfiguration.Fields.MailHeader)
            ? this.Content.Value<string>(DocumentTypes.MailConfiguration.Fields.MailHeader) : null;
        public string MailFooter => this.Content.HasValue(DocumentTypes.MailConfiguration.Fields.MailFooter)
            ? this.Content.Value<string>(DocumentTypes.MailConfiguration.Fields.MailFooter) : null;
        public string SenderMail => this.Content.HasValue(DocumentTypes.MailConfiguration.Fields.SenderMail)
            ? this.Content.Value<string>(DocumentTypes.MailConfiguration.Fields.SenderMail) : null;
        public string ReceiverMail => this.Content.HasValue(DocumentTypes.MailConfiguration.Fields.ReceiverMail)
            ? this.Content.Value<string>(DocumentTypes.MailConfiguration.Fields.ReceiverMail) : null;

        //public IEnumerable<string> ReceiverMail => this.Content.HasValue(DocumentTypes.MailConfiguration.Fields.ReceiverMail)
        //    ? this.Content.Value<IEnumerable<string>>(DocumentTypes.MailConfiguration.Fields.ReceiverMail) : null;


        public MailConfiguration(IPublishedContent content) : base(content)
        {
            
           
        }
    }
}

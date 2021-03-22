using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using System.ComponentModel.DataAnnotations;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Dit.Umb.ToolBox.Models.Configuration;

namespace Dit.Umb.ToolBox.Models.PageModels
{
    public class FormPage : BasePage
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string LabelName => Content.Value<string>("labelName");
        public string LabelFirstName => Content.Value<string>("labelFirstname");
        public string LabelAddress => Content.Value<string>("labelAddress");
        public string LabelZipCity => Content.Value<string>("labelZipCity");
        public string LabelMail => Content.Value<string>("labelMail");
        public string LabelPhone => Content.Value<string>("labelPhone");
        public string LabelMessage => Content.Value<string>("labelMessage");
        public MailConfiguration ReceiverConfiguration => Content.HasValue(DocumentTypes.FormPage.Fields.MailConfigurationReceiver) ? 
            new MailConfiguration(Content.Value<IPublishedContent>(DocumentTypes.FormPage.Fields.MailConfigurationReceiver)) : null;
        public MailConfiguration CustomerConfiguration => Content.HasValue(DocumentTypes.FormPage.Fields.MailConfigurationCustomer) ?
            new MailConfiguration(Content.Value<IPublishedContent>(DocumentTypes.FormPage.Fields.MailConfigurationCustomer)) : null;


        public ContactFormModel ContactFormModel { get; set; }

        public FormPage(IPublishedContent content) : base(content)
        {
           
        }
    }
}




using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IMailService
    {
        void SendConfirmationMailService(ContactFormModel model, IPublishedContent customer);
        void SendContactMailService(ContactFormModel model, IPublishedContent receiver);
    }
}

using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IMailService
    {
        void SendConfirmationMailService(ContactFormModel model, IPublishedContent customer);
        void SendContactMailService(ContactFormModel model, IPublishedContent receiver);
    }
}

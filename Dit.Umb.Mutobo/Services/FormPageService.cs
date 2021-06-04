using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PageModels;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Services
{
    public class FormPageService : BaseService, IFormPageService
    {
        private readonly IImageService _imageService;

        public FormPageService(IImageService imageService)
        {
            _imageService = imageService;
        }

        public FormPage GetFormPageModel(IPublishedContent content)
        {
            var result = new FormPage(content);

            result.ContactFormModel = new ContactFormModel()
            {
                LabelName = result.LabelName,
                LabelFirstName = result.LabelFirstName,
                LabelAddress = result.LabelAddress,
                LabelZipCity = result.LabelZipCity,
                LabelPhone = result.LabelPhone,
                LabelMail = result.LabelMail,
                LabelMessage = result.LabelMessage,
                Receiver = result.ReceiverConfiguration,
                Customer = result.CustomerConfiguration
            };

            return result;
        }
    }
}

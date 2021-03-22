using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services.Impl
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

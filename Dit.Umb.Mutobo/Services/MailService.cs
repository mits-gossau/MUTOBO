using System.Net.Mail;
using System.Text;
using Dit.Umb.Mutobo.Configuration;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Services
{
    public class MailService : BaseService, IMailService
    {
        private readonly IConfigurationService _configurationService;
        private readonly IImageService _imageService;
        protected readonly IPageLayoutService _pageLayoutService;

        public MailService(IConfigurationService configurationService, IImageService imageService, IPageLayoutService pageLayoutService)
        {
            _configurationService = configurationService;
            _imageService = imageService;
            _pageLayoutService = pageLayoutService;
        }

        public void SendConfirmationMailService(ContactFormModel model, IPublishedContent customer)
        {

            var custConfig = new MailConfiguration(customer);
            
            var strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head>");
            strBuilder.Append("</head>");
            strBuilder.Append("<body>");            

            strBuilder.Append(custConfig.MailHeader);
            strBuilder.Append(custConfig.MailBody);
            strBuilder.Append($"<p>Name: {model.Name}<br />");
            strBuilder.Append($"Vorname: {model.FirstName}<br />");
            strBuilder.Append($"Adresse: {model.Address}<br />");
            strBuilder.Append($"PLZ/Ort: {model.ZipCity}<br />");
            strBuilder.Append($"Telefon: {model.Phone}<br />");
            strBuilder.Append($"Email: {model.Mail}<br />");
            strBuilder.Append($"Nachricht: {model.Message}<br /></p>");
            strBuilder.Append(custConfig.MailFooter);


            strBuilder.Append("</body>");
            strBuilder.Append("</html>");


            var sendMail = new MailMessage()
            {
                From = new MailAddress(custConfig.SenderMail),
                Subject = custConfig.MailSubject,
                Body = strBuilder.ToString(),
                IsBodyHtml = true
            };

            sendMail.To.Add(model.Mail);
            


            SendMail(sendMail);
        }

        public void SendContactMailService(ContactFormModel model, IPublishedContent receiver)
        {
            var recConfig = new MailConfiguration(receiver);

            var strBuilder = new StringBuilder();

            strBuilder.Append("<html>");
            strBuilder.Append("<head>");
            strBuilder.Append("</head>");
            strBuilder.Append("<body>");

            strBuilder.Append(recConfig.MailHeader);
            strBuilder.Append(recConfig.MailBody);
            strBuilder.Append($"<p>Name: {model.Name}<br />");
            strBuilder.Append($"Vorname: {model.FirstName}<br />");
            strBuilder.Append($"Adresse: {model.Address}<br />");
            strBuilder.Append($"PLZ/Ort: {model.ZipCity}<br />");
            strBuilder.Append($"Telefon: {model.Phone}<br />");
            strBuilder.Append($"Email: {model.Mail}<br />");
            strBuilder.Append($"Nachricht: {model.Message}<br /></p>");
            strBuilder.Append(recConfig.MailFooter);

            strBuilder.Append("</body>");
            strBuilder.Append("</html>");

            var sendMail = new MailMessage()
            {
                From = new MailAddress(recConfig.SenderMail),
                Subject = recConfig.MailSubject,
                Body = strBuilder.ToString(),
                IsBodyHtml = true
            };

            string[] multipleMails = recConfig.ReceiverMail.Split(';');
            foreach (string tmpMails in multipleMails)
            {
                sendMail.To.Add(tmpMails);
            }


           SendMail(sendMail);
        }





        private void SendMail(MailMessage mail)
        {
            var mailServer = _configurationService.GetAppSettingValue("Toolbox.MailServer");
            var smtpClient = new SmtpClient(mailServer);

            smtpClient.Send(mail);
        }
    }
}

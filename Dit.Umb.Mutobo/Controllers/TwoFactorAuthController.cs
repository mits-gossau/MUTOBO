using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Windows.Controls;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Models;
using Dit.Umb.Mutobo.Services;
using Google.Authenticator;
using Superpower.Model;

using Umbraco.Core.Composing;
using Umbraco.Core.Persistence;
using Umbraco.Core.Scoping;
using Umbraco.Web.WebApi;

namespace Dit.Umb.Mutobo.Controllers
{

    public class TwoFactorAuthController : UmbracoAuthorizedApiController
    {
        private readonly TwoFactorService _twoFactorService;

        public TwoFactorAuthController(TwoFactorService twoFactorService)
        {
            _twoFactorService = twoFactorService;
        }

        [HttpGet]
        public List<TwoFactorAuthInfo> TwoFactorEnabled(int? id)
        {
            var user = Security.CurrentUser;
            var result = _twoFactorService.GetTwoFactorEnabled(user.Id);
            return result;
        }

        [HttpGet]
        public TwoFactorAuthInfo GoogleAuthenticatorSetupCode()
        {
            var tfa = new TwoFactorAuthenticator();
            var user = Security.CurrentUser;
            var accountSecretKey = Guid.NewGuid().ToString();

            var applicationName = ConfigurationManager.AppSettings["TfaApplicationName"];

            var setupInfo = tfa.GenerateSetupCode(applicationName, user.Email, accountSecretKey, false, 3);
            var twoFactorAuthInfo = _twoFactorService.GetExistingAccount(user.Id, Constants.TfaConstants.GoogleAuthenticatorProviderName, accountSecretKey);

            twoFactorAuthInfo.Secret = setupInfo.ManualEntryKey;
            twoFactorAuthInfo.Email = user.Email;
            twoFactorAuthInfo.ApplicationName = applicationName;
            twoFactorAuthInfo.QrCodeSetupImageUrl = setupInfo.QrCodeSetupImageUrl;

            return twoFactorAuthInfo;
        }

        [HttpPost]
        public bool ValidateAndSaveGoogleAuth(string code)
        {
            var user = Security.CurrentUser;
            return _twoFactorService.ValidateAndSaveGoogleAuth(code, user.Id);
        }

        [HttpPost]
        public bool Disable()
        {
            var result = 0;
            var isAdmin = Security.CurrentUser.Groups.Select(x => x.Name == "Administrators").FirstOrDefault();
            if (isAdmin)
            {
                var user = Security.CurrentUser;
                result = _twoFactorService.Disable(user.Id);
                //if more than 0 rows have been deleted, the query ran successfully
            }
            return result != 0;
        }
    }
}

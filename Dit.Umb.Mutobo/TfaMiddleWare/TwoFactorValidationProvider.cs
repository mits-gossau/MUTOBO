using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.Mutobo.Models;
using Google.Authenticator;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Umbraco.Core.Composing;
using Umbraco.Core.Models.Identity;

namespace Dit.Umb.Mutobo.TfaMiddleWare
{
    public class TwoFactorValidationProvider : DataProtectorTokenProvider<BackOfficeIdentityUser, int>, IUserTokenProvider<BackOfficeIdentityUser, int>
    {

        public TwoFactorValidationProvider(IDataProtector protector) : base(protector)
        { }

        /// <inheritdoc />
        /// <summary>
        /// Explicitly implement this interface method - which overrides the base class's implementation
        /// </summary>
        /// <param name="purpose"></param>
        /// <param name="token"></param>
        /// <param name="manager"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<bool> IUserTokenProvider<BackOfficeIdentityUser, int>.ValidateAsync(string purpose, string token, UserManager<BackOfficeIdentityUser, int> manager, BackOfficeIdentityUser user)
        {
            if (purpose == Constants.TfaConstants.GoogleAuthenticatorProviderName)
            {
                var twoFactorAuthenticator = new TwoFactorAuthenticator();

                using (var scope = Current.ScopeProvider.CreateScope(autoComplete: true))
                {

                    var result = scope.Database.Fetch<TwoFactor>(string.Format(
                        "WHERE [userId] = {0} AND [key] = '{1}' AND [confirmed] = 1",
                        user.Id, Constants.TfaConstants.GoogleAuthenticatorProviderName));
                    if (result.Any() == false)
                        return Task.FromResult(false);

                    var key = result.First().Value;
                    var validToken = twoFactorAuthenticator.ValidateTwoFactorPIN(key, token);
                    return Task.FromResult(validToken);
                }
            }

            /* if (purpose == Constants.YubiKeyProviderName)
             {
                 var yubiKeyService = new YubiKeyService();
                 var response = yubiKeyService.Validate(token, user.Id);
                 return Task.FromResult(response != null && response.Status == YubicoResponseStatus.Ok);
             }*/

            return Task.FromResult(false);
        }
    }
}

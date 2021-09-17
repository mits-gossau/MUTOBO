using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Models;
using Google.Authenticator;
using Umbraco.Core.Composing;
using Umbraco.Core.Scoping;

namespace Dit.Umb.Mutobo.Services
{
    public class TwoFactorService : ITwoFactorService
    {
        private readonly IScopeProvider scopeProvider;

        public TwoFactorService(IScopeProvider scopeProvider)
        {
            this.scopeProvider = scopeProvider;
        }

        public List<TwoFactorAuthInfo> GetTwoFactorEnabled(int id)
        {
            using (var scope = scopeProvider.CreateScope(autoComplete: true))
            {
                var result = scope.Database.Fetch<TwoFactor>("WHERE [userId] = @userId AND [confirmed] = 1", new { userId = id });

                var twoFactorAuthInfo = new List<TwoFactorAuthInfo>();
                foreach (var factor in result)
                {
                    var authInfo = new TwoFactorAuthInfo { ApplicationName = factor.Key };
                    twoFactorAuthInfo.Add(authInfo);
                }

                return twoFactorAuthInfo;
            }
        }

        public TwoFactorAuthInfo GetExistingAccount(int userId, string googleAuthenticatorProviderName, string accountSecretKey)
        {
            var twoFactorAuthInfo = new TwoFactorAuthInfo();

            using (var scope = scopeProvider.CreateScope(autoComplete: true))
            {
                try
                {
                    var existingAccount = scope.Database.Fetch<TwoFactor>(string.Format("WHERE userId = {0} AND [key] = '{1}'",
                        userId, Constants.TfaConstants.GoogleAuthenticatorProviderName));

                    if (existingAccount.Any())
                    {
                        var account = existingAccount.First();
                        if (account.Confirmed)
                            return twoFactorAuthInfo;

                        var tf = new TwoFactor { Value = accountSecretKey, UserId = userId, Key = Constants.TfaConstants.GoogleAuthenticatorProviderName };
                        var update = scope.Database.Update(tf);

                        if (update == 0)
                            return twoFactorAuthInfo;
                    }
                    else
                    {
                        var result = scope.Database.Insert(new TwoFactor { UserId = userId, Key = Constants.TfaConstants.GoogleAuthenticatorProviderName, Value = accountSecretKey, Confirmed = false });
                        if (result is bool == false)
                            return twoFactorAuthInfo;

                        var insertSucces = (bool)result;
                        if (insertSucces == false)
                            return twoFactorAuthInfo;
                    }
                }
                catch (Exception e)
                {
                    var result = scope.Database.Insert(new TwoFactor { UserId = userId, Key = Constants.TfaConstants.GoogleAuthenticatorProviderName, Value = accountSecretKey, Confirmed = false });
                    if (result is bool == false)
                        return twoFactorAuthInfo;

                    var insertSucces = (bool)result;
                    if (insertSucces == false)
                        return twoFactorAuthInfo;
                    //throw;
                }

                return twoFactorAuthInfo;
            }
        }

        public bool ValidateAndSaveGoogleAuth(string code, int userId)
        {
            using (var scope = scopeProvider.CreateScope(autoComplete: true))
            {
                try
                {
                    var twoFactorAuthenticator = new TwoFactorAuthenticator();
                    var all = scope.Database.Fetch<TwoFactor>("WHERE userId = @userId",
                        new { userId = userId });

                    var result = all.LastOrDefault(t => t.Key == Constants.TfaConstants.GoogleAuthenticatorProviderName);
                    if (result != null)
                    {
                        var isValid = twoFactorAuthenticator.ValidateTwoFactorPIN(result.Value, code);
                        if (isValid == false)
                            return false;

                        var tf = new TwoFactor
                        {
                            Confirmed = true,
                            Value = result.Value,
                            UserId = userId,
                            Key = Constants.TfaConstants.GoogleAuthenticatorProviderName
                        };
                        var update = scope.Database.Update(tf);
                        isValid = update > 0;
                        return isValid;
                    }
                }
                catch (Exception ex)
                {
                    Current.Logger.Error(typeof(TwoFactorService), ex);
                }

                return false;
            }
        }

        public int Disable(int userId)
        {
            using (var scope = scopeProvider.CreateScope(autoComplete: true))
            {
                var result = scope.Database.Delete<TwoFactor>("WHERE [userId] = @userId", new { userId = userId });

                return result;
            }
        }

    }
}

using System.Collections.Generic;
using Dit.Umb.Mutobo.Models;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ITwoFactorService
    {
        List<TwoFactorAuthInfo> GetTwoFactorEnabled(int id);

        TwoFactorAuthInfo GetExistingAccount(int userId, string googleAuthenticatorProviderName,
            string accountSecretKey);

        bool ValidateAndSaveGoogleAuth(string code, int userId);

        int Disable(int userId);
    }
}
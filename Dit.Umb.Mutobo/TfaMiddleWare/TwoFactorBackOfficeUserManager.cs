using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Umbraco.Core.Composing;
using Umbraco.Core.Configuration;
using Umbraco.Core.Configuration.UmbracoSettings;
using Umbraco.Core.Mapping;
using Umbraco.Core.Models.Identity;
using Umbraco.Core.Security;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace Dit.Umb.Mutobo.TfaMiddleWare
{
    public class TwoFactorBackOfficeUserManager : BackOfficeUserManager, IUmbracoBackOfficeTwoFactorOptions
    {
        public TwoFactorBackOfficeUserManager(IUserStore<BackOfficeIdentityUser, int> store) : base(store)
        { }

        /// <summary>
        /// Creates a BackOfficeUserManager instance with all default options and the default BackOfficeUserManager 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="userService"></param>
        /// <param name="entityService"></param>
        /// <param name="externalLoginService"></param>
        /// <param name="membershipProvider"></param>
        /// <returns></returns>
        public static TwoFactorBackOfficeUserManager Create(
            IdentityFactoryOptions<TwoFactorBackOfficeUserManager> options,
            IUserService userService,
            IMemberTypeService memberTypeService,
            IEntityService entityService,
            IExternalLoginService externalLoginService,
            MembershipProviderBase membershipProvider, IGlobalSettings globalSettings, UmbracoMapper umbracoMapper)
        {
            if (options == null) throw new ArgumentNullException("options");
            if (userService == null) throw new ArgumentNullException("userService");
            if (entityService == null) throw new ArgumentNullException("entityService");
            if (externalLoginService == null) throw new ArgumentNullException("externalLoginService");

            var manager = new TwoFactorBackOfficeUserManager(new TwoFactorBackOfficeUserStore(userService, memberTypeService, externalLoginService, entityService, membershipProvider, globalSettings, umbracoMapper));
            manager.InitUserManager(manager, membershipProvider, options.DataProtectionProvider, Current.Configs.GetConfig<IUmbracoSettingsSection>().Content);

            //Here you can specify the 2FA providers that you want to implement
            var dataProtectionProvider = options.DataProtectionProvider;
            manager.RegisterTwoFactorProvider(Constants.TfaConstants.GoogleAuthenticatorProviderName,
            new TwoFactorValidationProvider(dataProtectionProvider.Create(Constants.TfaConstants.GoogleAuthenticatorProviderName)));

            return manager;
        }

        /// <inheritdoc />
        /// <summary>
        /// Override to return true
        /// </summary>
        public override bool SupportsUserTwoFactor
        {
            get { return true; }
        }

        /// <summary>
        /// Return the view for the 2FA screen
        /// </summary>
        /// <param name="owinContext"></param>
        /// <param name="umbracoContext"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public string GetTwoFactorView(IOwinContext owinContext, UmbracoContext umbracoContext, string username)
        {
            return "../App_Plugins/2FactorAuthentication/2fa-login.html";
        }
    }
}

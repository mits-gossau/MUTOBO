using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Composing;
using Umbraco.Core.Configuration;
using Umbraco.Core.Mapping;
using Umbraco.Core.Models.Identity;
using Umbraco.Core.Security;
using Umbraco.Core.Services;

namespace Dit.Umb.Mutobo.TfaMiddleWare
{
    public class TwoFactorBackOfficeUserStore : BackOfficeUserStore
    {
        public TwoFactorBackOfficeUserStore(IUserService userService, IMemberTypeService memberService, IExternalLoginService externalLoginService,
            IEntityService entityService, MembershipProviderBase usersMembershipProvider, IGlobalSettings globalSettings, UmbracoMapper umbracoMapper)
            : base(userService, memberService, entityService, externalLoginService, globalSettings, usersMembershipProvider, umbracoMapper)
        { }

        /// <summary>
        /// Override to support setting whether two factor authentication is enabled for the user
        /// </summary>
        /// <param name="user"/><param name="enabled"/>
        /// <returns/>
        /// <remarks>
        /// This method is NOT designed to persist data! It's just meant to assign it, just like this
        /// </remarks>
        public override Task SetTwoFactorEnabledAsync(BackOfficeIdentityUser user, bool enabled)
        {
            user.TwoFactorEnabled = enabled;
            return Task.FromResult(0);
        }

        /// <summary>
        /// Returns whether two factor authentication is enabled for the user
        /// </summary>
        /// <param name="user"/>
        /// <returns/>
        public override Task<bool> GetTwoFactorEnabledAsync(BackOfficeIdentityUser user)
        {
            using (var scope = Current.ScopeProvider.CreateScope(autoComplete: true))
            {
                var result = scope.Database.Fetch<Models.TwoFactor>("WHERE [userId] = @userId AND [confirmed] = 1",
                    new { userId = user.Id });

                //if there's records for this user then we need to show the two factor screen
                return Task.FromResult(result.Any());
            }
        }
    }
}

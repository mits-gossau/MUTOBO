using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.Mutobo.Migration;
using Dit.Umb.Mutobo.Services;
using Dit.Umb.Mutobo.TfaMiddleWare;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Dit.Umb.Mutobo.Composer
{
    public class TfaComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // component for startup
            composition.Components().Append<TwoFactorMigrationComponent>();

            composition.Components().Append<TwoFactorEventHandler>();

            composition.Register<TwoFactorService>();
        }
    }
}

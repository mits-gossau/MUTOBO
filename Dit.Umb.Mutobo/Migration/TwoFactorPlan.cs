using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Migrations;

namespace Dit.Umb.Mutobo.Migration
{
    public class TwoFactorPlan : MigrationPlan
    {
        public TwoFactorPlan()
            : base("TwoFactor")
        {
            From(string.Empty)
                .To<CreateTwoFactorTable>("state-1");
        }
    }
}

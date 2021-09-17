using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;

namespace Dit.Umb.Mutobo.Migration
{
    public class CreateTwoFactorTable : MigrationBase
    {

        public CreateTwoFactorTable(IMigrationContext context)
            : base(context)
        {
        }

        public override void Migrate()
        {
            var tables = SqlSyntax.GetTablesInSchema(Context.Database).ToArray();
            if (tables.InvariantContains(Constants.TfaConstants.ProductName)) return;

            Create.Table(Constants.TfaConstants.ProductName)
                .WithColumn("userId").AsInt32().NotNullable()
                .WithColumn("key").AsString()
                .WithColumn("value").AsString()
                .WithColumn("confirmed").AsBoolean().Do();
        }
    }
}

using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20090314133900)]
    public class VersionFieldToEntitiesTables : FacturanetMigration
    {
        public override void  Up()
        {
            Database.AddColumn("AccountTree", CColVersion());
            Database.AddColumn("ContableConfiguration", CColVersion());
            Database.AddColumn("Customer", CColVersion());
            Database.AddColumn("Enterprise", CColVersion());
            Database.AddColumn("Invoice", CColVersion());
            Database.AddColumn("Product", CColVersion());
            Database.AddColumn("ContableAccount", CColVersion());
        }

        public override void Down()
        {
            Database.RemoveColumn("AccountTree", "Version");
            Database.RemoveColumn("ContableConfiguration", "Version");
            Database.RemoveColumn("Customer", "Version");
            Database.RemoveColumn("Enterprise", "Version");
            Database.RemoveColumn("Invoice", "Version");
            Database.RemoveColumn("Product", "Version");
            Database.RemoveColumn("ContableAccount", "Version");
        }
    }
}

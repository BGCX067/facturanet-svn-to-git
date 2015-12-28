using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20090320170900)]
    public class AddIsDeletedFieldToContableAccountTable : FacturanetMigration
    {
        public override void  Up()
        {
            Database.AddColumn("ContableAccount", CColIsDeleted());
        }

        public override void Down()
        {
            Database.RemoveColumn("ContableAccount", "IsDeleted");
        }
    }
}

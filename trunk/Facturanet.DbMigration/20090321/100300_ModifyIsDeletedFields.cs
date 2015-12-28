using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20090321100300)]
    public class ModifyIsDeletedFields : FacturanetMigration
    {
        public override void  Up()
        {
            Database.RenameColumn("AccountTree", "IsDeleted", "DeletedMark");
            Database.RemoveColumn("ContableAccount", "IsDeleted");
        }

        public override void Down()
        {
            Database.AddColumn("ContableAccount", CColIsDeleted());
            Database.RenameColumn("AccountTree", "DeletedMark", "IsDeleted");
        }
    }
}

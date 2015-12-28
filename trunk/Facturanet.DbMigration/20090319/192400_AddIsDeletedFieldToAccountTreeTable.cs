using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20090319192400)]
    public class AddIsDeletedFieldToAccountTreeTable : FacturanetMigration
    {
        public override void  Up()
        {
            Database.AddColumn("AccountTree", CColIsDeleted());
            //Database.RemoveConstraint("AccountTree", "UQ__AccountTree__145C0A3F");
            //Database.RemoveConstraint("AccountTree", "UQ__AccountTree__15502E78");
            Database.AddUniqueConstraint("UQ__AccountTree__Code", "AccountTree", new string[] { "Code", "IsDeleted" });
            Database.AddUniqueConstraint("UQ__AccountTree__Name", "AccountTree", new string[] { "Name", "IsDeleted" });
        }

        public override void Down()
        {
            Database.RemoveConstraint("AccountTree", "UQ__AccountTree__Code");
            Database.RemoveConstraint("AccountTree", "UQ__AccountTree__Name");
            Database.RemoveColumn("AccountTree", "IsDeleted");
        }
    }
}

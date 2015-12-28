using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20010101010160)]
    public class AddAccountTreeTable : Migration
    {
        public override void  Up()
        {
            Database.AddTable("AccountTree", new Column[]
            {
                new Column("Id", DbType.Guid, ColumnProperty.PrimaryKey),
                new Column("Code", DbType.String, 30, ColumnProperty.NotNull),
                new Column("Name", DbType.String, 50, ColumnProperty.NotNull),
                new Column("Description", DbType.String, 255, ColumnProperty.NotNull),
                new Column("Active", DbType.Boolean, 1, ColumnProperty.NotNull, true)
            });
        }

        public override void Down()
        {
            Database.RemoveTable("AccountTree");
        }
    }
}

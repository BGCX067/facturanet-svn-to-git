using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20010101010110)]
    public class AddEnterpriseTable : Migration
    {
        public override void Up()
        {
            Database.AddTable("Enterprise", new Column[]
            {
                new Column("Id", DbType.Guid, ColumnProperty.PrimaryKey),
                new Column("Code", DbType.String, 30, ColumnProperty.NotNull | ColumnProperty.Unique),
                new Column("Active", DbType.Boolean, 1, ColumnProperty.NotNull, true),
                new Column("Name", DbType.String, 100, ColumnProperty.NotNull | ColumnProperty.Unique)
            });
        }

        public override void Down()
        {
            Database.RemoveTable("Enterprise");
        }
    }
}

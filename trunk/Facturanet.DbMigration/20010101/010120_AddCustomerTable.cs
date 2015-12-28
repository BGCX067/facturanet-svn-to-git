using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20010101010120)]
    public class AddCustomerTable : Migration
    {
        public override void Up()
        {
            Database.AddTable("Customer", new Column[]
            {
                new Column("Id", DbType.Guid, ColumnProperty.PrimaryKey),
                new Column("Code", DbType.String, 30, ColumnProperty.NotNull | ColumnProperty.Unique),
                new Column("Active", DbType.Boolean, 1, ColumnProperty.NotNull, true),
                new Column("Name", DbType.String, 100, ColumnProperty.NotNull),
                new Column("FiscalType", DbType.String, 30, ColumnProperty.NotNull),
                new Column("FiscalId", DbType.String, 30, ColumnProperty.NotNull | ColumnProperty.Unique),
                new Column("Address", DbType.String, 255, ColumnProperty.NotNull)
            });
        }

        public override void Down()
        {
            Database.RemoveTable("Customer");
        }
    }
}

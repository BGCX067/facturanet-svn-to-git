using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20010101010130)]
    public class AddProductTable : Migration
    {
        public override void Up()
        {
            Database.AddTable("Product", new Column[]
            {
                new Column("Id", DbType.Guid, ColumnProperty.PrimaryKey),
                new Column("Code", DbType.String, 30, ColumnProperty.NotNull | ColumnProperty.Unique),
                new Column("Active", DbType.Boolean, 1, ColumnProperty.NotNull, true),
                new Column("Name", DbType.String, 100, ColumnProperty.NotNull),
                new Column("Taxes", DbType.Decimal, ColumnProperty.NotNull)
                
            });
        }

        public override void Down()
        {
            Database.RemoveTable("Product");
        }
    }
}
using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20010101010180)]
    public class AddContableConfigurationTable : Migration
    {
        public override void  Up()
        {
            Database.AddTable("ContableConfiguration", new Column[]
            {
                new Column("Id", DbType.Guid, ColumnProperty.PrimaryKey),
                new Column("Code", DbType.String, 30, ColumnProperty.NotNull),
                new Column("Name", DbType.String, 50, ColumnProperty.NotNull),
                new Column("Description", DbType.String, 255, ColumnProperty.NotNull),
                new Column("Active", DbType.Boolean, 1, ColumnProperty.NotNull, true),
                new Column("IdAccountTree", DbType.Guid, ColumnProperty.NotNull),
                new Column("IdDefaultAccount", DbType.Guid, ColumnProperty.NotNull),
            });

            Database.AddForeignKey("fk_ContableConfigurationAccount_AccountTree", "ContableConfiguration", "IdAccountTree", "AccountTree", "Id");
            Database.AddForeignKey("fk_ContableConfigurationAccount_DefaultAccount", "ContableConfiguration", "IdDefaultAccount", "ContableAccount", "Id");
        }

        public override void Down()
        {
            Database.RemoveTable("ContableConfiguration");
        }
    }
}

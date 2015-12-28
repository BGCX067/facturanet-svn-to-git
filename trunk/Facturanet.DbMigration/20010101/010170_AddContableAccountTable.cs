using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20010101010170)]
    public class AddContableAccountTable : Migration
    {
        public override void  Up()
        {
            Database.AddTable("ContableAccount", new Column[]
            {
                new Column("Id", DbType.Guid, ColumnProperty.PrimaryKey),
                new Column("Code", DbType.String, 30, ColumnProperty.NotNull),
                new Column("Name", DbType.String, 50, ColumnProperty.NotNull),
                new Column("Description", DbType.String, 255, ColumnProperty.NotNull),
                new Column("Imputable", DbType.Boolean, 1, ColumnProperty.NotNull, false),
                new Column("Active", DbType.Boolean, 1, ColumnProperty.NotNull, true),
                new Column("IdParentAccount", DbType.Guid, ColumnProperty.Null),
                new Column("IdAccountTree", DbType.Guid, ColumnProperty.NotNull)
            });

            //TODO: tengo que agregar la tabla empresa, las relaciones y los uniques

            //TODO: tengo que agregar una restriccion que Code y Name sean únicas para cada IdAccountTree
            Database.AddForeignKey("fk_ContableAccount_Parent", "ContableAccount", "IdParentAccount", "ContableAccount", "Id");
            Database.AddForeignKey("fk_ContableAccount_AccountTree", "ContableAccount", "IdAccountTree", "AccountTree", "Id");
        }

        public override void Down()
        {
            Database.RemoveTable("ContableAccount");
        }
    }
}

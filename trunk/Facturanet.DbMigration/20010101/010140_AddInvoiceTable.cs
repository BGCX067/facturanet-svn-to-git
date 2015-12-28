using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{

    [Migration(20010101010140)]
    public class AddInvoiceTable : FacturanetMigration
    {
        /// <summary>
        /// Defines tranformations to port the database to the current version.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "Invoice",
                CColId(),
                CColFK("IdEnterprise", false),
                CColString("FiscalType", 30),
                CColString("Number", 30),
                CColDateTime("Date", false),
                CColFK("IdCustomer", false));


            AddForeignKey("IdCustomer", "Customer");
            AddForeignKey("IdEnterprise", "Enterprise");
            //TODO: agregar la restriccion de unique para IdEnterprise junto con Number

            CreateTable(
                "InvoiceItem",
                CColFK("IdInvoice", false),
                new Column("InvoiceLine", DbType.Int32, ColumnProperty.NotNull),
                CColFK("IdProduct", false),
                new Column("Quantity", DbType.Decimal, ColumnProperty.NotNull),
                new Column("Price", DbType.Decimal, ColumnProperty.NotNull));

            AddForeignKey("IdProduct", "Product");
            AddForeignKey("IdInvoice", "Invoice");
            Database.AddPrimaryKey("InvoiceItemPK", "InvoiceItem", "IdInvoice", "InvoiceLine");
        }

        public override void Down()
        {
            Database.RemoveTable("InvoiceItem");
            Database.RemoveTable("Invoice");
        }
    }
}
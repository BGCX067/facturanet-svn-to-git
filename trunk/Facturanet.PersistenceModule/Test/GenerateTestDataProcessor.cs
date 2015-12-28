using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Entities;
using Facturanet.Server;
using Facturanet.Business;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Facturanet.Test
{
    internal class GenerateTestDataProcessor : PersistenceProcessor<GenerateTestDataRequest, GenerateTestDataResponse>
    {
        protected override GenerateTestDataResponse RunInContext(GenerateTestDataRequest request, PersistenceContext context)
        {
            var session = context.Session;

            session.Delete("from Invoice");
            session.Delete("from Product");
            session.Delete("from Customer");
            session.Delete("from Enterprise");

            session.Flush();
            //IQuery q1 = session.CreateQuery("from Enterprise");
            //var l1 = q1.List<Enterprise>();

            

            //IQuery q2 = session.CreateQuery("from Enterprise");
            //var l2 = q2.List<Enterprise>();



            Enterprise e1 = new Enterprise()
            {
                Code = "1",
                Name = "Roca Computacion"
            };
            session.Save(e1);

            //IQuery q3 = session.CreateQuery("from Enterprise");
            //var l3 = q3.List<Enterprise>();

            Customer c1 = new Customer()
            {
                Name = "Andrés Moschini",
                Address = "Calle Falsa 123",
                Code = "1",
                FiscalId = "20-26937659-8",
                FiscalType = "MONOTRIBUTISTA"
            };
            session.Save(c1);

            Product p1 = new Product()
            {
                Code = "1",
                Name = "Arroz",
                Taxes = 0.2
            };
            session.Save(p1);

            Invoice i1 = new Invoice()
            {
                Enterprise = e1,
                Customer = c1,
                Date = DateTime.Now,
                FiscalType = "A",
                Number = "123456",
                Items = new List<InvoiceItem>()
                    {
                        new InvoiceItem() 
                        {
                            Price = 10,
                            Product = p1,
                            Quantity = 10
                        }
                    }
            };
            session.Save(i1);

            return new GenerateTestDataResponse();
        }

    }
}

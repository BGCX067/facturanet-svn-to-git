using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Entities;
using Facturanet.Server;
using Facturanet.Business;
using Facturanet.Util;


namespace Facturanet.Business
{
    internal class GetProductsProcessor : Processor<ListProductsRequest, ListProductsResponse>
    {
        public override ListProductsResponse Run(ListProductsRequest request, IContext context)
        {
             /***/
            return new ListProductsResponse()
            /*
            {
                
                List = new List<Lines.ILineProduct>()
                {
                    new Product() { Id = IdentifierHelper.GenerateComb(), Taxes = 1, Name = "Articulo1" },
                    new Product() { Id = IdentifierHelper.GenerateComb(), Taxes = 2, Name = "Articulo2" },
                    new Product() { Id = IdentifierHelper.GenerateComb(), Taxes = 3, Name = "Articulo3" },
                    new Product() { Id = IdentifierHelper.GenerateComb(), Taxes = 4, Name = "Articulo4" }
                }
            }*/;
        }
    }
}

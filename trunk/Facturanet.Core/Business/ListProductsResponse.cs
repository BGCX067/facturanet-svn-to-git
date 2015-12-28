using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Business
{
    [DataContract]
    [KnownType(typeof(Entities.Product))]
    public class ListProductsResponse : ListResponse<UI.ProductsListItem>
    {
    }
}

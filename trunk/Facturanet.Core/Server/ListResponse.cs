using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using Facturanet.Entities;
using System.Runtime.Serialization;

namespace Facturanet.Server
{
    [DataContract]
    public abstract class ListResponse<T> : Response
    {
        [DataMember]
        public List<T> Items { get; set; }
    }
}

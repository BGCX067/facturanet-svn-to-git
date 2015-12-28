using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Facturanet.Server
{
    [DataContract]
    public class CompositeResponse : Response
    {
        [DataMember]
        public IList<Response> Responses { get; set; }

        public CompositeResponse()
        {
            Responses = new List<Response>();
        }
    }
}

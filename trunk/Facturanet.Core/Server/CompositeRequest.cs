using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Facturanet.Server
{
    [DataContract]
    public class CompositeRequest : BaseRequest<CompositeResponse>
    {
        [DataMember]
        public IList<Request> Requests { get; set; }

        public CompositeRequest()
        {
            Requests = new List<Request>();
        }
    }
}

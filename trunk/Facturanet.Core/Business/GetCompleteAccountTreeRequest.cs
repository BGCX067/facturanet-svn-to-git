using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Business
{
    [DataContract]
    public class GetCompleteAccountTreeRequest : BaseRequest<GetCompleteAccountTreeResponse>
    {
        [DataMember]
        public virtual Guid AccountTreeId { get; set; }
    }
}

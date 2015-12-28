using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Business
{
    [DataContract]
    [KnownType(typeof(UI.ContableAccount))]
    public class GetCompleteAccountTreeResponse : ListResponse<UI.ContableAccount>
    {
        [DataMember]
        public UI.AccountTreeListItem AccountTreeHeader { get; set; }
    }
}

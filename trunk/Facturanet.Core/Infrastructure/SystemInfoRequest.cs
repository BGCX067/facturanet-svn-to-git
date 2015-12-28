using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Infrastructure
{
    [DataContract]
    public class SystemInfoRequest : BaseRequest<SystemInfoResponse>
    {
    }
}

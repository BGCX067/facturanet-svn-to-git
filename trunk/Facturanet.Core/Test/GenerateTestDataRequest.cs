using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Test
{
    [DataContract]
    public class GenerateTestDataRequest : BaseRequest<GenerateTestDataResponse>
    {
    }
}

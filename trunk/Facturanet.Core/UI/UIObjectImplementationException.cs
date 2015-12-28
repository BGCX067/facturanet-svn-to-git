using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.UI
{
    public class UIObjectImplementationException : ApplicationException
    {
        public override string Message
        {
            get
            {
                return string.Format("{0} {1} is not available in {2}.",
                    base.TargetSite.Name,
                    base.TargetSite.MemberType,
                    base.TargetSite.DeclaringType.FullName);
            }
        }
    }
}

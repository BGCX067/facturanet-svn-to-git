using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Facturanet.Entities.Base
{
    public abstract class CustomerBase : Entity
    {
        public virtual string Code { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Name { get; set; }
        public virtual string FiscalType { get; set; }
        public virtual string FiscalId { get; set; }
        public virtual string Address { get; set; }
    }
}

namespace Facturanet.Entities
{
    public class Customer : Base.CustomerBase
    {
    }
}

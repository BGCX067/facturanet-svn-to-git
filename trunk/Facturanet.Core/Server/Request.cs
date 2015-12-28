using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;

namespace Facturanet.Server
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Request : Validation.IValidable
    {
        static private Type[] knownTypesCache = null;
        static Type[] GetKnownTypes()
        {
            if (knownTypesCache == null)
                knownTypesCache = FacturanetProcessorFactory.GetKnownTypesOf(typeof(Request));
            return knownTypesCache;
        }

        public Response Run()
        {
            return Run(null);
        }

        public Response Run(IContext context)
        {
            IProcessor processor = FacturanetProcessorFactory.Instance.CreateProcessor(this.GetType());
            return processor.Run(this, context);
        }

        #region Implement IValidable
        public virtual Validation.ValidationResult GetValidationResult(Validation.Level exceptionOverLevel)
        {
            return Validation.ValidationResult.Create(this);
        }
        #endregion

#if DEBUG
        public Response RunMock()
        {
            return RunMock(null);
        }

        public Response RunMock(IContext context)
        {
            IProcessor processor = FacturanetProcessorFactory.Instance.CreateProcessorMock(this.GetType());
            return processor.Run(this, context);
        }
#endif
    }
}

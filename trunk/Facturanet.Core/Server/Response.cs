using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Facturanet.Server
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Response
    {
        static private Type[] knownTypesCache = null;
        static Type[] GetKnownTypes()
        {
            if (knownTypesCache == null)
                knownTypesCache = FacturanetProcessorFactory.GetKnownTypesOf(typeof(Response), typeof(UI.IUIObject));
                //knownTypesCache = FacturanetProcessorFactory.GetKnownTypesOf(typeof(Response));
                //knownTypesCache = FacturanetProcessorFactory.GetKnownTypesOf(typeof(Response),typeof(Entities.ILines));
                //Funciona, pero lo comento porque en cada response evaluaría por cualquiera de las líneas
    
            return knownTypesCache;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Facturanet.Server
{
    //[DataContract]
    //public enum SelectorType
    //{
    //    Id,
    //    Example,
    //}

    [DataContract]
    public class Selector<EntityType>
    {
        //[DataMember]
        //public SelectorType SelectorType { get; set; }

        [DataMember]
        public bool Multiple { get; set; }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public EntityType Example { get; set; }

        //TODO: Terminar con los Selectores
    }
}

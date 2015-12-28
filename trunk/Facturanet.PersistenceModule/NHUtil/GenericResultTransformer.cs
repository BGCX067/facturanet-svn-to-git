using System;
using System.Collections;
using NHibernate;
using NHibernate.Properties;
using NHibernate.Transform;
using System.Reflection;

namespace Facturanet.NHUtil
{
    [Serializable]
    public class GenericResultTransformer<T> : IResultTransformer
    {
        private Func<object[], string[], T> transformation;

        public GenericResultTransformer(Func<object[], string[], T> transformation)
        {
            this.transformation = transformation;
        }

        public GenericResultTransformer(Func<object[], T> transformation)
        {
            this.transformation = (tuple, aliases) => transformation(tuple);
        }

        public IList TransformList(IList collection)
        {
            return collection;
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
            return transformation(tuple, aliases);
        }
    }
}
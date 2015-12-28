using System;
using System.Collections;
using NHibernate;
using NHibernate.Properties;
using NHibernate.Transform;
using System.Reflection;

namespace Facturanet.NHUtil
{
    /// <summary>
    /// Result transformer that allows to transform a result to 
    /// a user specified class which will be populated via setter  
    /// methods or fields matching the alias names. 
    /// </summary>
    /// <example>
    /// <code>
    /// IList resultWithAliasedBean = s.CreateQuery(select f.Name, f.Description from Foo f)
    /// 			.SetResultTransformer(new PositionalToBeanResultTransformer(typeof (NoFoo), new string[] {"_name", "_description"}))
    /// 			.List();
    /// 
    /// NoFoo dto = (NoFoo)resultWithAliasedBean[0];
    /// </code>
    /// </example>
    /// <remarks>
    /// If you have a <see cref="ICriteria"/> or a <see cref="IQuery"/> with aliases you can use
    /// <see cref="NHibernate.Transform.AliasToBeanResultTransformer"/> class.
    /// </remarks>
    [Serializable]
    public class PositionalToBeanResultTransformer : IResultTransformer
    {
        private readonly Type resultClass;
        private readonly string[] positionalAliases;
        private readonly object[] constants;
        private ISetter[] setters;
        private readonly IPropertyAccessor propertyAccessor;

        /// <summary>
        /// Initializes a new instance of the PositionalToBeanResultTransformer class.
        /// </summary>
        /// <param name="resultClass">The return <see cref="Type"/>.</param>
        /// <param name="positionalAliases">Alias for each position of the query.</param>
        public PositionalToBeanResultTransformer(Type resultClass, string[] positionalAliases)
        {
            if (resultClass == null)
            {
                throw new ArgumentNullException("resultClass");
            }
            this.resultClass = resultClass;
            if (positionalAliases == null || positionalAliases.Length == 0)
            {
                throw new ArgumentNullException("positionalAliases");
            }
            this.positionalAliases = positionalAliases;
            propertyAccessor =
                new ChainedPropertyAccessor(new[]
				                            	{
				                            		PropertyAccessorFactory.GetPropertyAccessor("field"),
				                            		PropertyAccessorFactory.GetPropertyAccessor(null)
				                            	});
            AssignSetters();
        }

        public PositionalToBeanResultTransformer(Type resultClass, string[] positionalAliases, params object[] constants)
            : this(resultClass, positionalAliases)
        {
            this.constants = constants;
        }

        private void AssignSetters()
        {
            setters = new ISetter[positionalAliases.Length];
            for (int i = 0; i < positionalAliases.Length; i++)
            {
                string alias = positionalAliases[i];
                if (!string.IsNullOrEmpty(alias))
                {
                    setters[i] = propertyAccessor.GetSetter(resultClass, alias);
                }
            }
        }

        #region IResultTransformer Members

        public IList TransformList(IList collection)
        {
            return collection;
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
            if (tuple.Length + (constants == null ? 0 : constants.Length) != setters.Length)
                throw new IndexOutOfRangeException("The setters lenght differs from the sum of tuple lenght and constants lenght");
            var result = Activator.CreateInstance(resultClass);

            for (int i = 0; i < tuple.Length; i++)
            {
                if (setters[i] != null)
                {
                    setters[i].Set(result, tuple[i]);
                }
            }

            if (constants != null)
                for (int i = 0; i < constants.Length; i++)
                {
                    int i_ = i + tuple.Length;
                    if (setters[i_] != null)
                    {
                        setters[i_].Set(result, constants[i]);
                    }
                }


            return result;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace uNhAddIns.Adapters.Common
{
	public class ConversationalMetaInfoHolder : IConversationalMetaInfoHolder
	{
		private readonly Dictionary<MethodInfo, IPersistenceConversationInfo> info =
			new Dictionary<MethodInfo, IPersistenceConversationInfo>(20);

		private readonly object locker = new object();

		public ConversationalMetaInfoHolder(Type conversationalClass, IPersistenceConversationalInfo setting)
		{
			if (conversationalClass == null)
			{
				throw new ArgumentNullException("conversationalClass");
			}
			if (setting == null)
			{
				throw new ArgumentNullException("setting");
			}
			ConversationalClass = conversationalClass;
			Setting = setting;
		}

		#region IConversationalMetaInfoHolder Members

		public Type ConversationalClass { get; private set; }

		public IPersistenceConversationalInfo Setting { get; private set; }

		public IEnumerable<MethodInfo> Methods
		{
			get { return info.Keys; }
		}

		readonly Func<MethodInfo, MethodInfo, bool> matchingMethod = (k, m) => k.DeclaringType.Equals(m.DeclaringType)
					  && k.Name.Equals(m.Name)
					  && k.GetParameters().Select(p => p.Name).SequenceEqual(m.GetParameters().Select(p => p.Name))
					  && k.GetParameters().Select(p => p.ParameterType).SequenceEqual(m.GetParameters().Select(p => p.ParameterType));

		public bool Contains(MethodInfo methodInfo)
		{
			return info.Keys.Any(k => matchingMethod(k,methodInfo));
		}

		public IPersistenceConversationInfo GetConversationInfoFor(MethodInfo methodInfo)
		{
			var key = info.Keys.FirstOrDefault(m => matchingMethod(m, methodInfo));
			if(key == null) return null;

			IPersistenceConversationInfo result;
			info.TryGetValue(key, out result);
			return result;
		}

		#endregion

		/// <summary>
		/// Add a method info.
		/// </summary>
		/// <param name="methodInfo">The method.</param>
		/// <param name="persistenceConversationInfo">The method settings</param>
		/// <exception cref="ArgumentNullException">When <paramref name="methodInfo"/> is null.</exception>
		/// <exception cref="ArgumentNullException">When <paramref name="persistenceConversationInfo"/> is null.</exception>
		public void AddMethodInfo(MethodInfo methodInfo, IPersistenceConversationInfo persistenceConversationInfo)
		{
			if (methodInfo == null)
			{
				throw new ArgumentNullException("methodInfo");
			}
			if (persistenceConversationInfo == null)
			{
				throw new ArgumentNullException("persistenceConversationInfo");
			}

			lock (locker)
			{
				info[methodInfo] = persistenceConversationInfo;
			}
		}
	}
}
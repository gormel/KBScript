using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Injection.Attributes;

namespace Injection.Main
{
	public static class InjectionManager
	{
		private static readonly Dictionary<Type, object> mSingletones = new Dictionary<Type, object>();

		public static void Connect(object obj)
		{
			var fields =	from f in obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
							let attr = f.GetCustomAttribute<InjectAttribute>()
							where attr != null
							select f;

			foreach (var field in fields)
			{
				field.SetValue(obj, GetInstance(field.FieldType));
			}
		}

		//TODO: ctor params
		internal static object GetInstance(Type type)
		{
			if (type.GetCustomAttributes(typeof (SingletoneAttribute)).Any())
			{
				if (!mSingletones.ContainsKey(type))
					mSingletones.Add(type, Activator.CreateInstance(type));
				return mSingletones[type];
			}

			return Activator.CreateInstance(type);
		}
	}
}

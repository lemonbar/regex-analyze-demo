using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace regex_analyze_demo.model
{
	public class Schema
	{
		private Dictionary<string, Tuple<Func<string>, Action<string>>> dictionary;
		internal static readonly HashSet<string> hashSet_0 = new HashSet<string> { "phone", "email", "address", "academic_degree", "english_level", "japanese_level", "career_objective_position" };

		internal bool method_0()
		{
			if (this.MustHaveFields == null)
			{
				return false;
			}
			return this.MustHaveFields.Any<string>(new Func<string, bool>(this.method_2));
		}

		private void initMethods(PropertyInfo propertyInfo)
		{
			this.dictionary[Util.formatClassName(propertyInfo.Name)] = new Tuple<Func<string>, Action<string>>((Func<string>) Delegate.CreateDelegate(typeof(Func<string>), this, propertyInfo.GetGetMethod()), (Action<string>) Delegate.CreateDelegate(typeof(Action<string>), this, propertyInfo.GetSetMethod()));
		}

		private bool method_2(string string_0)
		{
			return (this.Accessors[string_0].Item1() == null);
		}

		internal virtual void parser(Section_2 section2)
		{
			Class40 class2 = new Class40 {
				class42_0 = section2
			};
			this.Accessors.invokeMethod<KeyValuePair<string, Tuple<Func<string>, Action<string>>>>(new Action<KeyValuePair<string, Tuple<Func<string>, Action<string>>>>(class2.method_0));
		}

		protected Dictionary<string, Tuple<Func<string>, Action<string>>> Accessors
		{
			get
			{
				Action<PropertyInfo> action = null;
				if (this.dictionary == null)
				{
					this.dictionary = new Dictionary<string, Tuple<Func<string>, Action<string>>>();
					if (action == null)
					{
						action = new Action<PropertyInfo>(this.initMethods);
					}
					base.GetType().GetProperties().invokeMethod<PropertyInfo>(action);
				}
				return this.dictionary;
			}
		}

		protected virtual HashSet<string> MustHaveFields
		{
			get
			{
				return null;
			}
		}

		private sealed class Class40
		{
			public Section_2 class42_0;

			public void method_0(KeyValuePair<string, Tuple<Func<string>, Action<string>>> keyValuePair_0)
			{
				string str = this.class42_0.method_12(keyValuePair_0.Key);
				if (str != null)
				{
					Func<string> func = keyValuePair_0.Value.Item1;
					Action<string> action = keyValuePair_0.Value.Item2;
					string str2 = func();
					if (str2 == null)
					{
						action(str);
					}
					else if (hashSet_0.Contains(keyValuePair_0.Key))
					{
						action(string.Format("{0}; {1}", str2, str));
					}
				}
			}
		}
	}
}

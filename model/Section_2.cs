using System;

namespace regex_analyze_demo.model
{
	public class Section_2 : Text
	{
		private string type;
		private string language;
		private string mappingKey;
		
		public string MappingKey{
			get{return this.mappingKey;}
			set{this.mappingKey = value;}
		}
		
		public string Type{
			get{return this.type;}
			set{this.type = value;}
		}
		
		public string Language{
			get{return this.language;}
			set{this.language = value;}
		}
		
		public string method_12(string string_4)
		{
			Func<Class43, bool> predicate = null;
			Class25 class3 = new Class25 {
				string_0 = string_4
			};
			if (Class21.hashSet_0.Contains(class3.string_0))
			{
				Class26 class2 = new Class26 {
					class25_0 = class3
				};
				if (predicate == null)
				{
					predicate = new Func<Class43, bool>(class3.method_0);
				}
				if (func_3 == null)
				{
					func_3 = new Func<Class43, string>(Class42.smethod_4);
				}
				class2.list_0 = this.method_10().Where<Class43>(predicate).Select<Class43, string>(func_3).Distinct<string>().ToList<string>();
				string str = string.Join("; ", class2.list_0.Where<string>(new Func<string, bool>(class2.method_0)));
				if (!str.isEmpty())
				{
					return str;
				}
				return null;
			}
			if (func_4 == null)
			{
				func_4 = new Func<Class43, string>(Class42.smethod_5);
			}
			return this.method_10().Where<Class43>(new Func<Class43, bool>(class3.method_1)).Select<Class43, string>(func_4).FirstOrDefault<string>();
		}
	}
}

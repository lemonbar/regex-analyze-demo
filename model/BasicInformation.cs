using System;

namespace regex_analyze_demo.model
{
	/// <summary>
	/// Description of BasicInformation.
	/// </summary>
	public class BasicInformation : Schema
	{
		private string name;
		private string age;
		private string gendar;
		
		public string Name{
			get{return this.name;}
			set{this.name = value;}
		}
		
		public string Age{
			get{return this.age;}
			set{this.age = value;}
		}
		
		public string Gendar{
			get{return this.gendar;}
			set{this.gendar = value;}
		}
		
		internal override void parser(Section_2 section2)
		{
			base.parser(section2);
//			if ((this.Name == null) && (section2.method_6() || section2.method_0().StartsWith("other")))
//			{
//				this.Name = section2.method_16();
//			}
		}
	}
}

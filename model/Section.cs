using System;

namespace regex_analyze_demo.model
{
	/// <summary>
	/// Description of Section.
	/// </summary>
	public class Section : Text
	{
		private string language;
		private string type;
		
		public string Language{
			get{return this.language;}
			set{this.language = value;}
		}
		
		public string Type{
			get{return this.type;}
			set{this.type = value;}
		}
		
		public Section_2 newSection2(string mappingKey)
		{
			Section_2 section2 = new Section_2();
			section2.Type = this.Type;
			section2.Content = base.Content;
			section2.Language = this.Language;
			section2.MappingKey = mappingKey;
			return section2;
		}
	}
}

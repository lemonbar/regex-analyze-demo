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
	}
}

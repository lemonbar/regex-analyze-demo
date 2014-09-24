using System;

namespace regex_analyze_demo.model
{
	/// <summary>
	/// Description of Resume.
	/// </summary>
	public class Resume : Text
	{
		private string language;
		
		public string Language{
			get{return this.language;}
			set{this.language = value;}
		}
	}
}

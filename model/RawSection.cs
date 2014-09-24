using System;

namespace regex_analyze_demo.model
{
	/// <summary>
	/// Description of Section.
	/// </summary>
	public class RawSection : Text
	{
		private string string1 = null;
		private string string2 = null;
		//always return null, because don't know this string value usage.
		public string getString1()
		{
			return this.string1;
		}
		
		public string getSectionType()
		{
			if (this.string2 == null)
			{
				if (this.getString1() == null)
				{
					this.string2 = null;
				}
				else if (this.getString1().Contains("_content_"))
				{
					this.string2 = this.getString1().Substring(this.getString1().IndexOf("_content_") + 9);
				}
				else if (this.getString1().Contains("_keyword_"))
				{
					this.string2 = this.getString1().Substring(this.getString1().IndexOf("_keyword_") + 9);
				}
				else
				{
					this.string2 = this.getString1();
				}
			}
			return this.string2;
		}

	}
}

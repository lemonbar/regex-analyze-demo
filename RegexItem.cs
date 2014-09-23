using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace regex_analyze_demo
{
	/// <summary>
	/// Description of RegexItem.
	/// </summary>
	public class RegexItem
	{
		private static readonly Regex charRegex = new Regex(@"[a-z\p{IsCJKUnifiedIdeographs}]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
		private Regex regex;
//		private string fullKey;
		private string parentKey;
		private string itemKey;
		private string itemValue;
		
		public string ParentKey
		{
			get{return parentKey;}
			set{parentKey = value;}
		}
		public string ItemKey
		{
			get{return itemKey;}
			set{itemKey = value;}
		}
		public string ItemValue
		{
			get{return itemValue;}
			set{itemValue = value;}
		}
		
		public Regex getRegex()
		{
			if (this.regex == null)
			{
				if (this.ParentKey.EndsWith("_section_content"))
				{
					//for example: contact_information###联系方式|联络方式
					if (this.ItemValue.Contains(@"\n"))
					{
						this.regex = new Regex(this.ItemValue, RegexOptions.Compiled);
					}
					else
					{
						//return value is:
						//^(联\s*系\s*方\s*式|联\s*络\s*方\s*式)$|\n\n(联\s*系\s*方\s*式|联\s*络\s*方\s*式)\s|^(联\s*系\s*方\s*式|联\s*络\s*方\s*式)\([\p{{IsCJKUnifiedIdeographs}}\d]{{2,7}}\)$|\b(联\s*系\s*方\s*式|联\s*络\s*方\s*式)\t
						this.regex = new Regex(string.Format(@"^({0})$|\n\n({0})\s|^({0})\([\p{{IsCJKUnifiedIdeographs}}\d]{{2,7}}\)$|\b({0})\t", addEmptyCharBetweenChinessChars(this.ItemValue)), RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
					}
				}
				else if (this.ParentKey.EndsWith("_keyword"))
				{
					if (charRegex.IsMatch(this.ItemValue))
					{
						this.regex = new Regex(string.Format(@"(?<=\b|\d)({0})\b", addEmptyCharBetweenChinessChars(this.ItemValue)), RegexOptions.Compiled | RegexOptions.IgnoreCase);
					}
					else
					{
						this.regex = new Regex(string.Format(@"(?<=\b|\d)({0})", addEmptyCharBetweenChinessChars(this.ItemValue)), RegexOptions.Compiled | RegexOptions.IgnoreCase);
					}
				}
				else
				{
					this.regex = new Regex(string.Format("{0}", this.ItemValue), RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.IgnoreCase);
					if (this.regex.GetGroupNumbers().Length <= 1)
					{
						this.regex = new Regex(string.Format("({0})", this.ItemValue), RegexOptions.IgnorePatternWhitespace | RegexOptions.Compiled | RegexOptions.IgnoreCase);
					}
				}
			}
			return this.regex;
		}

		//for example:
		//	input: 	"联系方式|联络方式"
		//	return:	 "联\s*系\s*方\s*式|联\s*络\s*方\s*式".
		private static string addEmptyCharBetweenChinessChars(string pattern)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < (pattern.Length - 1); i++)
			{
				builder.Append(pattern[i]);
				if (Util.isSimpleChinessChar(pattern[i]) && Util.isSimpleChinessChar(pattern[i + 1]))
				{
					builder.Append(@"\s*");
				}
			}
			builder.Append(pattern.Last<char>());
			return builder.ToString();
		}
	}
}

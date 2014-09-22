using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace regex_analyze_demo
{
	/// <summary>
	/// Description of RegexItem.
	/// </summary>
	public class RegexItem
	{
		private static readonly Regex regex_0 = new Regex(@"[a-z\p{IsCJKUnifiedIdeographs}]$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
//		private Regex regex_1;
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
	}
}

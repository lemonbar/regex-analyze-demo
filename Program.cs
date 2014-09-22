using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace regex_analyze_demo
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			
			// parser mapping file
			Dictionary<string, IEnumerable<string>> mapping = MappingFile.getMappingDictionary();
			
			//parser regex files
			Dictionary<string, IEnumerable<RegexItem>> regexDictionary = RegexFiles.getRegexDictionary();
			
			IEnumerable<RegexItem> sectionRegexItems = getRegexItems("zh","section","content");
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public static IEnumerable<RegexItem> getRegexItems(string language, string folder, string file)
		{
			string key = string.Format("{0}_{1}_{2}", language, folder, file).Trim('_');
			if (RegexFiles.getRegexDictionary().ContainsKey(key))
			{
				return RegexFiles.getRegexDictionary()[key];
			}
			return new List<RegexItem>();
		}
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace regex_analyze_demo
{
	class Program
	{
		private static string content = "姓名：李四；手机：13333333333；性别：男；";
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Parsing begin...");
			
			Resume resume = new Resume();
			resume.Content = content;
			
			// parser mapping file
			Dictionary<string, IEnumerable<string>> mapping = MappingFile.getMappingDictionary();
			
			//parser regex files
			Dictionary<string, IEnumerable<RegexItem>> regexDictionary = RegexFiles.getRegexDictionary();
			
			//get zh_section_content regex items.
			IEnumerable<RegexItem> sectionRegexItems = getRegexItems("zh","section","content");
			
			//parser resume content.
			foreach(RegexItem item in sectionRegexItems){
				
			}
			
			Console.WriteLine("Parsing done!");
			Console.Write("Press any key to exit . . . ");
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
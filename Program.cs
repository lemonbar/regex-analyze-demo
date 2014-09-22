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
			
			RegexFiles.getRegexDictionary();
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}
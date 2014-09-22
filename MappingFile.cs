using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace regex_analyze_demo
{
	public class MappingFile
	{
		private static string mappingFilePath = @"C:\MyWorkspace\Projects\Git\regex-csharp\regex-analyze-demo\data";
		private static Dictionary<string, IEnumerable<string>> mappingDictionary;
		
		public static Dictionary<string, IEnumerable<string>> getMappingDictionary(){
			if(mappingDictionary == null){
				mappingDictionary = parserMappingFile();
			}
			return mappingDictionary;
		}
		
		private static bool isValidLine(string content)
		{
			return (!string.IsNullOrWhiteSpace(content) && !content.StartsWith(";"));
		}
		
		private static Dictionary<string, IEnumerable<string>> parserMappingFile()
		{
			Dictionary<string, IEnumerable<string>> dictionary = new Dictionary<string, IEnumerable<string>>();
			using (StreamReader reader = new StreamReader(Path.Combine(mappingFilePath, "mapping.ini")))
			{
				string[] rawResult = reader.ReadToEnd().Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
				
				//iterate each line which is not empty and is not commented in file mapping.ini.
				foreach (string tmp in rawResult.Select(t => t.Trim()).Where(t => isValidLine(t)))
				{
					string[] strArray = tmp.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries).Select(t => t.Trim()).ToArray<string>();
					dictionary[strArray[0]] = strArray[1].Split(new string[] { ";", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
				}
			}
			return dictionary;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace regex_analyze_demo
{
	/// <summary>
	/// Description of RegexFiles.
	/// </summary>
	public class RegexFiles
	{
		private static string filePath = @"C:\MyWorkspace\Projects\Git\regex-csharp\regex-analyze-demo\data\Regex";
		private static Dictionary<string, IEnumerable<RegexItem>> regexDictionary;
		
		public static Dictionary<string, IEnumerable<RegexItem>> getRegexDictionary(){
			if(regexDictionary == null){
				regexDictionary = parserRegexDictionary();
			}
			return regexDictionary;
		}
		
		private static Dictionary<string, IEnumerable<RegexItem>> parserRegexDictionary(){
			Dictionary<string, IEnumerable<RegexItem>> dictionary = new Dictionary<string, IEnumerable<RegexItem>>();
			
//			//foreach all files in regex folder.
//			foreach (string str2 in Directory.GetFiles(path))
//			{
//				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(str2);
//				dictionary[fileNameWithoutExtension] = smethod_4(str2, fileNameWithoutExtension);
//			}
			//foreach all directories in regex folder, such as zh.
			foreach (string directory1 in Directory.GetDirectories(filePath))
			{
				string fileName = Path.GetFileName(directory1);
				//foreach all directories in zh folder, such as basic_information.
				foreach (string directory2 in Directory.GetDirectories(directory1))
				{
					string subFileName = Path.GetFileName(directory2);
//					if (func_3 == null)
//					{
//						//func_3 is used to get extension, sort the files list by extension value.
//						func_3 = new Func<string, string>(Class21.getFileExtension);
//					}
					foreach (string tmp in Directory.GetFiles(directory2))//.OrderBy<string, string>(func_3))
					{
						string shortName = Path.GetFileNameWithoutExtension(tmp);
						//an example for key value is zh_basic_information_keyword
						string key = string.Format("{0}_{1}_{2}", fileName, subFileName, shortName);
						Console.Write(key);
						Console.WriteLine();
//						if (!dictionary.ContainsKey(key))
//						{
//							dictionary[key] = new List<Class23>();
//						}
//						//str8 value is c:/.../zh/basic_information/keyword.txt
//						//key value is zh_basic_information_keyword
//						((List<Class23>) dictionary[key]).AddRange(smethod_4(tmp, key));
					}
				}
			}
			
			return dictionary;
		}
	}
}

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
					foreach (string tmp in Directory.GetFiles(directory2).OrderBy(t => Path.GetExtension(t)))
					{
						string shortName = Path.GetFileNameWithoutExtension(tmp);
						//an example for key value is zh_basic_information_keyword
						string key = string.Format("{0}_{1}_{2}", fileName, subFileName, shortName);

						if (!dictionary.ContainsKey(key))
						{
							dictionary[key] = new List<RegexItem>();
						}
						
//						Console.Write(key);
//						Console.WriteLine();
						
						((List<RegexItem>)dictionary[key]).AddRange(parserRegexFile(tmp, key));
					}
				}
			}
			
			return dictionary;
		}
		
		private static IEnumerable<RegexItem> parserRegexFile(string file, string key)
		{
			IEnumerable<RegexItem> items = new List<RegexItem>();
			if(file.EndsWith(".txt")){
				using (StreamReader reader = new StreamReader(file))
				{
					string[] lines = reader.ReadToEnd().Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries).Where(t => isValidLine(t)).ToArray<string>();
					
					foreach(string line in lines){
						((List<RegexItem>)items).Add(newItemByLine(line,key));
					}
					return items;
				}
			}
			if (!file.EndsWith(".xml"))
			{
				throw new ArgumentException("unknown regular expression configuration file type: " + file);
			}
			foreach(XElement element in XElement.Load(file).Elements("regex")){
				((List<RegexItem>)items).Add(newItemByXElement(element,key));
			}
			return items;
		}
		
		private static RegexItem newItemByLine(string content,string key)
		{
			string[] array = splitLine(content);
			RegexItem item = new RegexItem();
			item.ParentKey = key;
			item.ItemKey = array[0];
			item.ItemValue = array[1].Trim();
			return item;
		}
		
		private static RegexItem newItemByXElement(XElement xelement,string key)
		{
			RegexItem item = new RegexItem();
			item.ParentKey = key;
			item.ItemKey = xelement.Element("key").Value;
			item.ItemValue = xelement.Element("value").Value;
			return item;
		}
		
		private static bool isValidLine(string content)
		{
			return (!string.IsNullOrWhiteSpace(content) && !content.StartsWith("//"));
		}
		
		private static string[] splitLine(string content)
		{
			return content.Split(new string[] { "###" }, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}

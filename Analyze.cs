using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using regex_analyze_demo.model;

namespace regex_analyze_demo
{
	public class Analyze
	{
		private static void doInit(){
			// parser mapping file
			Dictionary<string, IEnumerable<string>> mapping = MappingFile.getMappingDictionary();
		}
		
		public static void doAnalyze(Resume resume){
			doInit();
			
			Console.WriteLine("Parsing begin...");
			
			string className = "BasicInformation";
			
			string mappingKey = formatClassName(className);
			
			foreach(string keyword in getMappingDictionaryValue(mappingKey)){
				
				//get zh_section_content regex items.
				IEnumerable<RegexItem> sectionRegexItems = getRegexItems(resume.Language,"section","content");
				
				IEnumerable<Section> sections = getSectionsByKey(resume, sectionRegexItems,keyword);
			}
			
			Console.WriteLine("Parsing done!");
			Console.Write("Press any key to exit . . . ");
			Console.ReadKey(true);
		}
		
		private static IEnumerable<Section> getSectionsByKey(Resume resume, IEnumerable<RegexItem> sectionRegexItems, string mappingKey){
			List<Section> sections = new List<Section>();
			IList<RawSection> rawSections = getRawSections(resume,sectionRegexItems);
			if (rawSections.Count != 0)
			{
				for (int i = 0; i < rawSections.Count; i++)
				{
					RawSection current = rawSections[i];
					RawSection next = (i < (rawSections.Count - 1)) ? rawSections[i + 1] : null;
					if (current.getString1() == null)
					{
						Section section = new Section();
						section.Type = "other";
						section.Content = current.Content;
						section.Language = resume.Language;
						sections.Add(section);
					}
					else if ((next != null) && (next.getString1() == null))
					{
						Section section = new Section();
						section.Type = current.getSectionType();
						section.Content = next.Content;
						section.Language = resume.Language;
						sections.Add(section);
						i++;
					}
				}
			}
			return sections.Where(t => (t.Type == mappingKey));
		}
		
		private static IList<RawSection> getRawSections(Resume resume, IEnumerable<RegexItem> sectionRegexItems){
			RawSection first = new RawSection();
			first.Content = resume.Content;
			IList<RawSection> rawSections = new List<RawSection>();
			rawSections.Add(first);
			return parserRawSections(rawSections,sectionRegexItems);
		}
		
		private static IList<RawSection> parserRawSections(IList<RawSection> sections,IEnumerable<RegexItem> sectionRegexItems){
			foreach(RegexItem item in sectionRegexItems){
				sections = parserRawSectionsBySingleRegex(sections, item);
			}
			return sections;
		}
		
		private static IList<RawSection> parserRawSectionsBySingleRegex(IList<RawSection> sections, RegexItem regexItem){
			IList<RawSection> result = new List<RawSection>();
			foreach(RawSection section in sections){
				string[] strArray = regexItem.getRegex().Split(section.Content);
				if (strArray.Length < 2)
				{
					result.Add(section);
				}
				else
				{
					Console.WriteLine("else branch is reached.");
				}
			}
			return result;
		}
		
		private static IEnumerable<RegexItem> getRegexItems(string language, string folder, string file)
		{
			string key = string.Format("{0}_{1}_{2}", language, folder, file).Trim('_');
			if (RegexFiles.getRegexDictionary().ContainsKey(key))
			{
				return RegexFiles.getRegexDictionary()[key];
			}
			return new List<RegexItem>();
		}
		
		public static string formatClassName(string className)
		{
			return Util.classNameRegex.Replace(className, "$1_$2").ToLower();
		}
		
		private static IEnumerable<string> getMappingDictionaryValue(string mappingKey)
		{
			return MappingFile.getMappingDictionary()[mappingKey];
		}
	}
}

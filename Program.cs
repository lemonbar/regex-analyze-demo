using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using regex_analyze_demo.model;

namespace regex_analyze_demo
{
	class Program
	{
		private static string content = "姓名：李四；手机：13333333333；性别：男；";
		
		public static void Main(string[] args)
		{
			Resume resume = new Resume();
			resume.Content = content;
			resume.Language = "zh";

			Analyze.doAnalyze(resume);
		}
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace regex_analyze_demo
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	public class Util
	{
		private static readonly Regex simpleChinessRegex = new Regex(@"\p{IsCJKUnifiedIdeographs}", RegexOptions.Compiled);
//		//{Sm} is 数学符号, {P} is 标点, {So} is 其它符号。
//		private static readonly Regex regex_1 = new Regex(@"(?:^[\s\p{Sm}\p{P}\p{So}]+)|(?:[\s\p{Sm}\p{P}\p{So}]+$)", RegexOptions.Compiled);
//		private static readonly Regex regex_2 = new Regex(@"\n{3,}", RegexOptions.Compiled);
		public static readonly Regex classNameRegex = new Regex(@"(\p{Ll})(\p{Lu})", RegexOptions.Compiled);

		public static bool isSimpleChinessChar(char character)
		{
			return simpleChinessRegex.IsMatch(character.ToString());
		}
	}
}

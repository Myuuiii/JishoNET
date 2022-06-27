using System;

namespace JishoNET.Models
{
	public class JishoKanjiDefinition
	{
		public String Kanji;
		public string[] Meanings { get; set; }
		public string[] KunyomiReadings { get; set; }
		public string[] OnyomiReadings { get; set; }
		public int Strokes { get; set; }
	}
}
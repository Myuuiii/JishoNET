using System;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
	public class JishoJapaneseDefinition
	{
		/// <summary>
		/// Japanese word, shown in Kanji or Kana
		/// </summary>
		[JsonPropertyName("word")]
		public string Word { get; set; }

		/// <summary>
		/// Kana reading of the word
		/// </summary>
		[JsonPropertyName("reading")]
		public string Reading { get; set; }
	}
}
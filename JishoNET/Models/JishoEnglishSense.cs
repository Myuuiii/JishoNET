using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
	public class JishoEnglishSense
	{
		/// <summary>
		/// List of all the English Readings of the word
		/// </summary>
		[JsonPropertyName("english_definitions")]
		public List<string> EnglishDefinitions { get; set; }

		/// <summary>
		/// Speech part information, e.g. "Noun"
		/// </summary>
		[JsonPropertyName("parts_of_speech")]
		public List<string> PartsOfSpeech { get; set; }

		/// <summary>
		/// Any links provided with the definition
		/// </summary>
		[JsonPropertyName("links")]
		public List<JishoLink> Links { get; set; }

		/// <summary>
		/// Any tags provided with the definition
		/// </summary>
		[JsonPropertyName("tags")]
		public List<string> Tags { get; set; }

		/// <summary>
		/// List of restrictions
		/// </summary>
		[JsonPropertyName("restrictions")]
		public List<object> Restrictions { get; set; }

		/// <summary>
		/// List of referenced definitions/readings
		/// </summary>
		[JsonPropertyName("see_also")]
		public List<string> SeeAlso { get; set; }

		/// <summary>
		/// List of antonyms
		/// </summary>
		[JsonPropertyName("antonyms")]
		public List<string> Antonyms { get; set; }

		/// <summary>
		/// Source of the definition
		/// </summary>
		[JsonPropertyName("source")]
		public List<object> Source { get; set; }

		/// <summary>
		/// Any additional information that has been provided alongside the definition
		/// </summary>
		[JsonPropertyName("info")]
		public List<string> Info { get; set; }

		/// <summary>
		/// List of example sentences
		/// </summary>
		[JsonPropertyName("sentences")]
		public List<object> Sentences { get; set; }
	}
}
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
		public List<String> EnglishDefinitions { get; set; }

		/// <summary>
		/// Speech part information, e.g. "Noun"
		/// </summary>
		[JsonPropertyName("parts_of_speech")]
		public List<String> PartsOfSpeech { get; set; }

		/// <summary>
		/// Any links provided with the definition
		/// </summary>
		[JsonPropertyName("links")]
		public List<JishoLink> Links { get; set; }

		/// <summary>
		/// Any tags provided with the definition
		/// </summary>
		[JsonPropertyName("tags")]
		public List<String> Tags { get; set; }

		/// <summary>
		/// List of restrictions
		/// </summary>
		[JsonPropertyName("restrictions")]
		public List<Object> Restrictions { get; set; }

		/// <summary>
		/// List of referenced definitions/readings
		/// </summary>
		[JsonPropertyName("see_also")]
		public List<String> SeeAlso { get; set; }

		/// <summary>
		/// List of antonyms
		/// </summary>
		[JsonPropertyName("antonyms")]
		public List<String> Antonyms { get; set; }

		/// <summary>
		/// Source of the definition
		/// </summary>
		[JsonPropertyName("source")]
		public List<Object> Source { get; set; }

		/// <summary>
		/// Any additional information that has been provided alongside the definition
		/// </summary>
		[JsonPropertyName("info")]
		public List<String> Info { get; set; }

		/// <summary>
		/// List of example sentences
		/// </summary>
		[JsonPropertyName("sentences")]
		public List<Object> Sentences { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JishoNET.Models;

public class JishoDefinition
{
	[JsonPropertyName("slug")]
	public string Slug { get; set; }

	/// <summary>
	/// Indicates if the given word is commonly used in the Japanese language
	/// </summary>
	[JsonPropertyName("is_common")]
	public bool IsCommon { get; set; }

	/// <summary>
	/// Any tags that Jisho has attatched to this definition
	/// </summary>
	[JsonPropertyName("tags")]
	public List<string> Tags { get; set; }

	/// <summary>
	/// Starting JLPT level that the word or character cant be included in
	/// </summary>
	[JsonPropertyName("jlpt")]
	public List<string> Jlpt { get; set; }

	/// <summary>
	/// All Japanese Readings of the word or character
	/// </summary>
	[JsonPropertyName("japanese")]
	public List<JishoJapaneseDefinition> Japanese { get; set; }

	/// <summary>
	/// All the senses containing the English definitions amongst other information
	/// </summary>
	[JsonPropertyName("senses")]
	public List<JishoEnglishSense> Senses { get; set; }

	/// <summary>
	/// Attribution Info
	/// </summary>
	[JsonPropertyName("attribution")]
	public JishoAttribution Attribution { get; set; }
}
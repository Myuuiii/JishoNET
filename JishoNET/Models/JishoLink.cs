using System;
using System.Text.Json.Serialization;

namespace JishoNET.Models;

public class JishoLink
{
	/// <summary>
	/// HyperLink Text
	/// </summary>
	[JsonPropertyName("text")]
	public string Text { get; set; }

	/// <summary>
	/// HyperLink Target Url
	/// </summary>
	[JsonPropertyName("url")]
	public string Url { get; set; }
}
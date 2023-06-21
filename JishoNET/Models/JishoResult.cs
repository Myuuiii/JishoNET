using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JishoNET.Models;

public class JishoResult<T>
{
	/// <summary>
	/// Meta data that is returned by the API
	/// </summary>
	[JsonPropertyName("meta")]
	public JishoMeta Meta { get; set; }

	/// <summary>
	/// Array of definitions that were returned by the API using the given search term keyword
	/// </summary>
	[JsonPropertyName("data")]
	public T Data { get; set; }

	/// <summary>
	/// Indicates if the request was executed successfully 
	/// </summary>
	[JsonIgnore]
	public bool Success { get; set; }

	/// <summary>
	/// Any exception information, this will only be provided if something goes wrong during the creation or processing of your request
	/// </summary>
	[JsonIgnore]
	public string? Exception { get; set; }
}
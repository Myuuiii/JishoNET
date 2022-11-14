using System;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
	public class JishoAttribution
	{
		/// <summary>
		/// jmdict attribution
		/// </summary>
		[JsonPropertyName("jmdict")]
		public bool JmDict { get; set; }

		/// <summary>
		/// jmnedict attribution
		/// </summary>
		[JsonPropertyName("jmnedict")]
		public bool JmneDict { get; set; }

		/// <summary>
		/// dbpedia attribution
		/// </summary>
		[JsonPropertyName("dbpedia")]
		public object DbPedia { get; set; }
	}
}
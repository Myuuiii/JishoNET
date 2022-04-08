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
		public Boolean JmDict { get; set; }

		/// <summary>
		/// jmnedict attribution
		/// </summary>
		[JsonPropertyName("jmnedict")]
		public Boolean JmneDict { get; set; }

		/// <summary>
		/// dbpedia attribution
		/// </summary>
		[JsonPropertyName("dbpedia")]
		public Object DbPedia { get; set; }
	}
}
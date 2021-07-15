using System;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
    public class Link
    {
        /// <summary>
        /// HyperLink Text
        /// </summary>
        [JsonPropertyName("text")]
        public String Text { get; set; }

        /// <summary>
        /// HyperLink Target Url
        /// </summary>
        [JsonPropertyName("url")]
        public String Url { get; set; }
    }
}
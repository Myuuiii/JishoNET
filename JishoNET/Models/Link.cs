using System;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    public class Link
    {
        /// <summary>
        /// HyperLink Text
        /// </summary>
        [JsonProperty("text")]
        public String Text { get; set; }

        /// <summary>
        /// HyperLink Target Url
        /// </summary>
        [JsonProperty("url")]
        public String Url { get; set; }
    }
}
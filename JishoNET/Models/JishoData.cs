using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    public class JishoData
    {
        [JsonProperty("slug")]
        public String Slug { get; set; }

        /// <summary>
        /// Indicates if the given word is commonly used in the Japanese language
        /// </summary>
        [JsonProperty("is_common")]
        public Boolean IsCommon { get; set; }

        /// <summary>
        /// Any tags that Jisho has attatched to this definition
        /// </summary>
        [JsonProperty("tags")]
        public List<String> Tags { get; set; }

        /// <summary>
        /// Starting JLPT level that the word or character cant be included in
        /// </summary>
        [JsonProperty("jlpt")]
        public List<String> Jlpt { get; set; }

        /// <summary>
        /// All Japanese Readings of the word or character
        /// </summary>
        [JsonProperty("japanese")]
        public List<Japanese> Japanese { get; set; }

        /// <summary>
        /// All the senses containing the English definitions amongst other information
        /// </summary>
        [JsonProperty("senses")]
        public List<Sense> Senses { get; set; }
        
        /// <summary>
        /// Attribution Info
        /// </summary>
        [JsonProperty("attribution")]
        public Attribution Attribution { get; set; }
    }
}
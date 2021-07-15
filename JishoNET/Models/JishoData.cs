using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
    public class JishoData
    {
        [JsonPropertyName("slug")]
        public String Slug { get; set; }

        /// <summary>
        /// Indicates if the given word is commonly used in the Japanese language
        /// </summary>
        [JsonPropertyName("is_common")]
        public Boolean IsCommon { get; set; }

        /// <summary>
        /// Any tags that Jisho has attatched to this definition
        /// </summary>
        [JsonPropertyName("tags")]
        public List<String> Tags { get; set; }

        /// <summary>
        /// Starting JLPT level that the word or character cant be included in
        /// </summary>
        [JsonPropertyName("jlpt")]
        public List<String> Jlpt { get; set; }

        /// <summary>
        /// All Japanese Readings of the word or character
        /// </summary>
        [JsonPropertyName("japanese")]
        public List<Japanese> Japanese { get; set; }

        /// <summary>
        /// All the senses containing the English definitions amongst other information
        /// </summary>
        [JsonPropertyName("senses")]
        public List<Sense> Senses { get; set; }
        
        /// <summary>
        /// Attribution Info
        /// </summary>
        [JsonPropertyName("attribution")]
        public Attribution Attribution { get; set; }
    }
}
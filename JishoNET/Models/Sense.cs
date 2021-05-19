using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    public class Sense
    {
        /// <summary>
        /// List of all the English Readings of the word
        /// </summary>
        [JsonProperty("english_definitions")]
        public List<String> EnglishDefinitions { get; set; }

        /// <summary>
        /// Speech part information, e.g. "Noun"
        /// </summary>
        [JsonProperty("parts_of_speech")]
        public List<String> PartsOfSpeech { get; set; }

        /// <summary>
        /// Any links provided with the definition
        /// </summary>
        [JsonProperty("links")]
        public List<Link> Links { get; set; }

        /// <summary>
        /// Any tags provided with the definition
        /// </summary>
        [JsonProperty("tags")]
        public List<String> Tags { get; set; }

        /// <summary>
        /// List of restrictions
        /// </summary>
        [JsonProperty("restrictions")]
        public List<Object> Restrictions { get; set; }

        /// <summary>
        /// List of referenced definitions/readings
        /// </summary>
        [JsonProperty("see_also")]
        public List<String> SeeAlso { get; set; }

        /// <summary>
        /// List of antonyms
        /// </summary>
        [JsonProperty("antonyms")]
        public List<String> Antonyms { get; set; }

        /// <summary>
        /// Source of the definition
        /// </summary>
        [JsonProperty("source")]
        public List<Object> Source { get; set; }
        
        /// <summary>
        /// Any additional information that has been provided alongside the definition
        /// </summary>
        [JsonProperty("info")]
        public List<String> Info { get; set; }

        /// <summary>
        /// List of example sentences
        /// </summary>
        [JsonProperty("sentences")]
        public List<Object> Sentences { get; set; }
    }
}
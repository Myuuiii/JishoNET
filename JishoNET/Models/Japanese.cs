using System;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    public class Japanese
    {
        /// <summary>
        /// Japanese word, shown in Kanji or Kana
        /// </summary>
        [JsonProperty("word")]
        public String Word { get; set; }

        /// <summary>
        /// Kana reading of the word
        /// </summary>
        [JsonProperty("reading")]
        public String Reading { get; set; }
    }
}
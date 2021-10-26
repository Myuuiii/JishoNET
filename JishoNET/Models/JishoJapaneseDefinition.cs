using System;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
    public class JishoJapaneseDefinition
    {
        /// <summary>
        /// Japanese word, shown in Kanji or Kana
        /// </summary>
        [JsonPropertyName("word")]
        public String Word { get; set; }

        /// <summary>
        /// Kana reading of the word
        /// </summary>
        [JsonPropertyName("reading")]
        public String Reading { get; set; }
    }
}
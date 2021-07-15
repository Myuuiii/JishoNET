using System;
using System.Text.Json.Serialization;

namespace JishoNET.Models
{
    public class Meta
    {
        /// <summary>
        /// Http Response Code
        /// </summary>
        [JsonPropertyName("status")]
        public Int32 Status { get; set; }
    }
}
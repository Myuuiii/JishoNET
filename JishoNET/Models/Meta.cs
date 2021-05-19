using System;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    public class Meta
    {
        /// <summary>
        /// Http Response Code
        /// </summary>
        [JsonProperty("status")]
        public Int32 Status { get; set; }
    }
}
using System;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    public class Attribution
    {
        /// <summary>
        /// jmdict attribution
        /// </summary>
        [JsonProperty("jmdict")]
        public Boolean JmDict { get; set; }

        /// <summary>
        /// jmnedict attribution
        /// </summary>
        [JsonProperty("jmnedict")]
        public Boolean JmneDict { get; set; }

        /// <summary>
        /// dbpedia attribution
        /// </summary>
        [JsonProperty("dbpedia")]
        public Object DbPedia { get; set; }
    }
}
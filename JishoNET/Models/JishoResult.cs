using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    public class JishoResult
    {
        /// <summary>
        /// Meta data that is returned by the API
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        /// <summary>
        /// List of definitions that were returned by the API using the given search term keyword
        /// </summary>
        [JsonProperty("data")]
        public List<JishoData> Data { get; set; }

        /// <summary>
        /// Indicates if the request was executed successfully 
        /// </summary>
        [JsonIgnore]
        public Boolean Success { get; set; }

        /// <summary>
        /// Any exception information, this will only be provided if something goes wrong during the creation or processing of your request
        /// </summary>
        [JsonIgnore]
        public String Exception { get; set; }
    }
}
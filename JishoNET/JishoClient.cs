using System;
using System.Net;
using Newtonsoft.Json;

namespace JishoNET.Models
{
    /// <summary>
    /// Jisho API Client used to retrieve definitions
    /// </summary>
    public class JishoClient
    {
        private static Uri BaseUrl = new Uri("https://jisho.org/api/v1/search/words?keyword=");

        /// <summary>
        /// Retrieve a a list of results from the Jisho API using the given keyword as a search term
        /// </summary>
        /// <param name="keyword">Keyword used as a search term to find definitions</param>
        /// <returns><see cref="JishoResult" /> containing all definitions</returns>
        public JishoResult GetDefinition(String keyword)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                webClient.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
                webClient.Encoding = System.Text.Encoding.UTF8;

                String jsonResponse = webClient.DownloadString(new Uri(BaseUrl + keyword));
                JishoResult result = JsonConvert.DeserializeObject<JishoResult>(jsonResponse);
                result.Success = true;
                return result;
            }
            catch (Exception e)
            {
                return new JishoResult()
                {
                    Success = false,
                    Exception = e.ToString()
                };
            }
        }
    }
}
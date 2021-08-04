using System;
using System.Net;
using System.Text.Json;

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
				JishoResult result = JsonSerializer.Deserialize<JishoResult>(jsonResponse);
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

		/// <summary>
		/// Quickly retrieve the top most result from Jisho using the given keyword as a search term
		/// </summary>
		/// <param name="keyword">Keyword used as a search term to quickly retrieve an English <see cref="Sense" /> and a <see cref="Japanese" /> Reading</param>
		/// <returns><see cref="QuickDefinition" /> containing the top English <see cref="Sense" />  and <see cref="Japanese" /> Reading of the search term OR null if no definition was found</returns>
		public QuickDefinition GetQuickDefinition(String keyword)
		{
			try
			{
				return new QuickDefinition(GetDefinition(keyword));
			}
			catch (Exception e)
			{
				return new QuickDefinition()
				{
					Success = false,
					Exception = e.ToString()
				};
			}
		}
	}
}
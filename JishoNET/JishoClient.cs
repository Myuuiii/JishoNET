using System;
using System.Collections.Generic;
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
		public JishoResult<List<JishoDefinition>> GetDefinition(String keyword)
		{
			try
			{
				WebClient webClient = new WebClient();
				webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
				webClient.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
				webClient.Encoding = System.Text.Encoding.UTF8;

				String jsonResponse = webClient.DownloadString(new Uri(BaseUrl + keyword));
				JishoResult<List<JishoDefinition>> result = JsonSerializer.Deserialize<JishoResult<List<JishoDefinition>>>(jsonResponse);
				result.Success = true;
				return result;
			}
			catch (Exception e)
			{
				return new JishoResult<List<JishoDefinition>>()
				{
					Success = false,
					Exception = e.ToString()
				};
			}
		}

		/// <summary>
		/// Quickly retrieve the top most result from Jisho using the given keyword as a search term
		/// </summary>
		/// <param name="keyword">Keyword used as a search term to quickly retrieve an English <see cref="JishoEnglishSense" /> and a <see cref="JishoJapaneseDefinition" /> Reading</param>
		/// <returns><see cref="JishoQuickDefinition" /> containing the top English <see cref="JishoEnglishSense" />  and <see cref="JishoJapaneseDefinition" /> Reading of the search term OR null if no definition was found</returns>
		public JishoResult<JishoQuickDefinition> GetQuickDefinition(String keyword)
		{
			try
			{
				JishoResult<JishoQuickDefinition> result = new JishoResult<JishoQuickDefinition>();
				result.Data = new JishoQuickDefinition(GetDefinition(keyword));
				result.Success = true;
				return result;
			}
			catch (Exception e)
			{
				return new JishoResult<JishoQuickDefinition>()
				{
					Success = false,
					Exception = e.ToString()
				};
			}
		}
	}
}
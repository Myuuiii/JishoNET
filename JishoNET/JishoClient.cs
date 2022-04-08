using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace JishoNET.Models
{
	/// <summary>
	/// Jisho API Client used to retrieve definitions
	/// </summary>
	public class JishoClient
	{
		private static Uri BaseUrl = new Uri("https://jisho.org/api/v1/search/words?keyword=");

		/// <summary>
		/// Retrieve a list of results from the Jisho API using the given keyword as a search term asynchronously
		/// </summary>
		/// <param name="keyword">Keyword used as a search term to find definitions</param>
		/// <returns><see cref="JishoResult" /> containing all definitions</returns>
		public async Task<JishoResult<JishoDefinition>> GetDefinitionAsync(String keyword)
		{
			try
			{
				HttpClient client = new HttpClient();
				var response = await client.GetAsync(BaseUrl + keyword);
				JishoResult<JishoDefinition> result = JsonSerializer.Deserialize<JishoResult<JishoDefinition>>(response.Content.ReadAsStringAsync().Result);
				result.Meta.Status = ((int)response.StatusCode);
				result.Success = true;
				return result;
			}
			catch (Exception e)
			{
				return new JishoResult<JishoDefinition>()
				{
					Success = false,
					Exception = e.ToString()
				};
			}
		}
		
		/// <summary>
		/// Retrieve a list of results from the Jisho API using the given keyword as a search term
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns></returns>
		public JishoResult<JishoDefinition> GetDefinition(String keyword) {
			return this.GetDefinitionAsync(keyword).Result;
		}

		/// <summary>
		/// Quickly retrieve the top most result from Jisho using the given keyword as a search term asynchronously
		/// </summary>
		/// <param name="keyword">Keyword used as a search term to quickly retrieve an English <see cref="JishoEnglishSense" /> and a <see cref="JishoJapaneseDefinition" /> Reading</param>
		/// <returns><see cref="JishoQuickDefinition" /> containing the top English <see cref="JishoEnglishSense" />  and <see cref="JishoJapaneseDefinition" /> Reading of the search term OR null if no definition was found</returns>
		public async Task<JishoQuickDefinition> GetQuickDefinitionAsync(String keyword)
		{
			try
			{
				JishoQuickDefinition result = new JishoQuickDefinition();
				result = new JishoQuickDefinition(await GetDefinitionAsync(keyword));
				result.Success = true;
				return result;
			}
			catch (Exception e)
			{
				return new JishoQuickDefinition()
				{
					Success = false,
					Exception = e.ToString()
				};
			}
		}

		/// <summary>
		/// Quickly retrieve the top most result from Jisho using the given keyword as a search term
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns></returns>
		public JishoQuickDefinition GetQuickDefinition(String keyword) {
			return this.GetQuickDefinitionAsync(keyword).Result;
		}
	}
}
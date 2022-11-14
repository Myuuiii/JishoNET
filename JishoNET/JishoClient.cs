using System;
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
		private static readonly Uri BaseUrl = new("https://jisho.org/api/v1/search/words?keyword=");

		/// <summary>
		/// Retrieve a list of results from the Jisho API using the given keyword as a search term asynchronously
		/// </summary>
		/// <param name="keyword">Keyword used as a search term to find definitions</param>
		/// <returns><see cref="JishoResult{T}" /> containing all definitions</returns>
		public async Task<JishoResult<JishoDefinition[]>> GetDefinitionAsync(string keyword)
		{
			try
			{
				HttpClient client = new();
				HttpResponseMessage response = await client.GetAsync(BaseUrl + keyword);
				JishoResult<JishoDefinition[]> result = JsonSerializer.Deserialize<JishoResult<JishoDefinition[]>>(response.Content.ReadAsStringAsync().Result);
				result.Meta.Status = ((int)response.StatusCode);
				result.Success = true;
				return result;
			}
			catch (Exception e)
			{
				return new JishoResult<JishoDefinition[]>
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
		public JishoResult<JishoDefinition[]> GetDefinition(string keyword)
		{
			return GetDefinitionAsync(keyword).Result;
		}

		/// <summary>
		/// Quickly retrieve the top most result from Jisho using the given keyword as a search term asynchronously
		/// </summary>
		/// <param name="keyword">Keyword used as a search term to quickly retrieve an English <see cref="JishoEnglishSense" /> and a <see cref="JishoJapaneseDefinition" /> Reading</param>
		/// <returns><see cref="JishoQuickDefinition" /> containing the top English <see cref="JishoEnglishSense" />  and <see cref="JishoJapaneseDefinition" /> Reading of the search term OR null if no definition was found</returns>
		public async Task<JishoResult<JishoQuickDefinition>> GetQuickDefinitionAsync(string keyword)
		{
			try
			{
				JishoResult<JishoQuickDefinition> result = new()
				{
					Data = new JishoQuickDefinition(await GetDefinitionAsync(keyword)),
					Success = true,
					Exception = null
				};
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

		/// <summary>
		/// Quickly retrieve the top most result from Jisho using the given keyword as a search term
		/// </summary>
		/// <param name="keyword"></param>
		/// <returns></returns>
		public JishoResult<JishoQuickDefinition> GetQuickDefinition(string keyword)
		{
			return GetQuickDefinitionAsync(keyword).Result;
		}
	}
}
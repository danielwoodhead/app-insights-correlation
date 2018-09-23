using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api1.Controllers
{
	public class ValuesClient : IValuesClient
	{
		private readonly HttpClient _httpClient;

		public ValuesClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<string>> GetAsync()
		{
			var response = await _httpClient.GetAsync("api/values");

			response.EnsureSuccessStatusCode();

			return await response.Content.ReadAsAsync<IEnumerable<string>>();
		}
	}
}

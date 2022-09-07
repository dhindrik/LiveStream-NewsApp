using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using NewsApp.Models;

namespace NewsApp.Services
{
	public class NewsService : INewsService
	{
        private const string DataUrl = "https://cgmobiledev8947.blob.core.windows.net/livecode/f1.json";
        private HttpClient httpClient;

        public NewsService()
		{
            httpClient = new HttpClient();
		}

        public async Task<List<NewsItem>> Get()
        {
            var response = await httpClient.GetAsync(DataUrl);

            if(response.StatusCode == System.Net.HttpStatusCode.NotModified)
            {

            }
            else if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<List<NewsItem>>(json, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return result;
            }

            return new List<NewsItem>();
        }
    }
}


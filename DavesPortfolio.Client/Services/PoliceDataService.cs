using DavesPortfolio.Client.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace DavesPortfolio.Client.Services
{
    public class PoliceDataService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PoliceDataService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<CrimeRecord>> GetCrimesAsync(string lat, string lng)
        {
            var client = _clientFactory.CreateClient("PoliceApi");
            var url = $"crimes-street/all-crime?lat={lat}&lng={lng}";
            return await client.GetFromJsonAsync<List<CrimeRecord>>(url);
        }

        public async Task<List<Polforceloc>> GetForcesAsync()
        {
            var client = _clientFactory.CreateClient("PoliceApi");
            return await client.GetFromJsonAsync<List<Polforceloc>>("forces");
        }

        public async Task<List<CrimeCategories>> GetCategoriesAsync()
        {
            var client = _clientFactory.CreateClient("PoliceApi");
            return await client.GetFromJsonAsync<List<CrimeCategories>>("crime-categories");
        }

        public async Task<List<Neighbourhood>> GetNeighbourhoodsAsync(string forceId)
        {
            var client = _clientFactory.CreateClient("PoliceApi");
            var url = $"{forceId}/neighbourhoods";
            return await client.GetFromJsonAsync<List<Neighbourhood>>(url);
        }

        public async Task<List<Latlng>> GetBoundryAsync(string forceId, string nHoodId)
        {
            var client = _clientFactory.CreateClient("PoliceApi");
            var url = $"{forceId}/{nHoodId}/boundary";
            return await client.GetFromJsonAsync<List<Latlng>>(url);
        }

        public async Task<List<CrimeRecord>> GetCrimesNoLocationAsync(string forceId, string category)
        {
            Console.WriteLine($"Force : {forceId}, Category: {category}");

            if (string.IsNullOrWhiteSpace(forceId))
            {
                return new List<CrimeRecord>();
            }

            var client = _clientFactory.CreateClient("PoliceApi");
            var url = $"crimes-no-location?category={category.Trim()}&force={forceId.Trim()}";

            try
            {
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw API response: {content}");

                response.EnsureSuccessStatusCode();
                var crimes = JsonSerializer.Deserialize<List<CrimeRecord>>(content);
                Console.WriteLine($"Deserialized {crimes?.Count ?? 0} crimes");
                return crimes ?? new List<CrimeRecord>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing crimes: {ex.Message}");
                return new List<CrimeRecord>();
            }
        }
    }
}

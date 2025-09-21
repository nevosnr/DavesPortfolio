using DavesPortfolio.Client.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DavesPortfolio.Client.Services
{
    public class PoliceDataService
    {
        private readonly HttpClient _http;

        public PoliceDataService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CrimeRecord>> GetCrimesAsync(double lat, double lng)
        {
            var url = $"crimes-street/all-crime?lat={lat}&lng={lng}";
            return await _http.GetFromJsonAsync<List<CrimeRecord>>(url);
        }

        public async Task<List<Polforceloc>> GetForcesAsync()
        {
            return await _http.GetFromJsonAsync<List<Polforceloc>>("forces");
        }
        public async Task<List<CrimeCategories>> GetCategoriesAsync()
        {
            return await _http.GetFromJsonAsync<List<CrimeCategories>>("crime-categories");
        }

        public async Task<List<Neighbourhood>> GetNeighbourhoodsAsync(string forceId)
        {
            var url = $"{forceId}/neighbourhoods";
            return await _http.GetFromJsonAsync<List<Neighbourhood>>(url);
        }

        public async Task<List<Latlng>> GetBoundryAsync(string forceId, string nHoodId)
        {
            var url = $"{forceId}/{nHoodId}/boundary";
            return await _http.GetFromJsonAsync<List<Latlng>>(url);
        }
    }
}

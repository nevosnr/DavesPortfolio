using DavesPortfolio.Client.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DavesPortfolio.Client.Services
{
    public class PoliceDataService
    {
        private readonly HttpClient _http;

        public PoliceDataService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("PoliceAPI");
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
    }
}

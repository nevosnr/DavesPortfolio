using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace DavesPortfolio.Controllers
{
    [Route("api/crimes")]
    [ApiController]
    public class CrimesController : ControllerBase
    {
        private readonly HttpClient _http;

        public CrimesController(HttpClient http)
        {
            _http = http;
        }

        [HttpPost("by-boundary")]
        public async Task<IActionResult> GetCrimesByBoundary([FromBody] string poly)
        {
            var url = $"https://data.police.uk/api/crimes-street/all-crime?poly={poly}";
            var response = await _http.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}



using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("by-boundary")]
        public async Task<IActionResult> GetCrimesByBoundary([FromQuery] string poly)
        {
            var url = $"https://data.police.uk/api/crimes-street/all-crime?poly={poly}";
            var response = await _http.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}

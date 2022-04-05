using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            ViewData["Message"] = "Hello from Web Frontend";

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage();
                // request.RequestUri = new Uri("https://localhost:55176/weatherforecast");
                // request.RequestUri = new Uri("http://api/WeatherForecast");
                // request.RequestUri = new Uri("https://localhost:55052/weatherforecast");
                // var response = await client.SendAsync(request);
                // ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
                ViewData["Message"] = " test test";
            }
        }
    }
}

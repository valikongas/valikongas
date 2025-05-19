using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API_Nr._4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WheatherController : Controller
    {
        public readonly WheatherData _wheatherData;

        public WheatherController(WheatherData wheatherData)
        {
            _wheatherData = wheatherData;
        }

        [HttpGet("GetWheather")]
        public async void GetWheatherAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://api.weatherstack.com/current?access_key=b4c38ad5b723997d5afb7ae53a3af64b&query=New York")
            };
            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var wheatherData = JsonSerializer.Deserialize<WheatherData>(body, options);

            //  wheatherData yra gaves is puslapio duomenis.

        }








    }
}

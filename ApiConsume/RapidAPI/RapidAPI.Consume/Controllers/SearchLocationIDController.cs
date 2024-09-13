using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Consume.Models;

namespace RapidAPI.Consume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/meta/locationToLatLong?query={cityName}"),
                    Headers =
                    {
                        { "x-rapidapi-key", "b6b39990eamsh33db6774594052bp1e1332jsnaebcaf8690ed" },
                        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                    },
                    };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    // Deserialize into a single object, not a list
                    var model = JsonConvert.DeserializeObject<SearchRootobject>(body);
                    return View(model);
                }
            }
            else 
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/locationToLatLong?query=paris"),
                    Headers =
                    {
                        { "x-rapidapi-key", "b6b39990eamsh33db6774594052bp1e1332jsnaebcaf8690ed" },
                        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
                    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    // Deserialize into a single object, not a list
                    var model = JsonConvert.DeserializeObject<SearchRootobject>(body);
                    return View(model);
                }
            }
        }
    }
}

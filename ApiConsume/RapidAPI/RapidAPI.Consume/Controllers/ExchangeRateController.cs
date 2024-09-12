using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Consume.Models;

public class ExchangeRateController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=USD"),
            Headers =
            {
                { "x-rapidapi-key", "ba6a2cf21amsh6fbebb56a934146p159edcjsn6de3df7fee09" },
                { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            // Deserialize JSON into your ViewModel
            var exchangeData = JsonConvert.DeserializeObject<Rootobject>(body);

            // Pass the data to the view
            return View(exchangeData);
        }
    }
}

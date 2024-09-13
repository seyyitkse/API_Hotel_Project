using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Consume.Models;

namespace RapidAPI.Consume.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-741919&search_type=CITY&arrival_date=2024-09-14&departure_date=2024-09-16&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=AED"),
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
                var bookingData = JsonConvert.DeserializeObject<BookingRootobject>(body);
                return View(bookingData);
            }
        }
    }
}

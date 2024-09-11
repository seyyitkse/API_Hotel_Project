using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPI.Consume.Models;
namespace RapidAPI.Consume.Controllers
{
    public class DefaultController : Controller
    {
        public async Task< IActionResult> Index()
        {
            List<ImdbViewModel> imdbList = new List<ImdbViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com"),
                Headers =
            {
                { "x-rapidapi-key", "9b86eb187emsh4ff8019e6473f3ep135f00jsnfc55dd15b8a3" },
                { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
            },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                imdbList=JsonConvert.DeserializeObject<List<ImdbViewModel>>(body);
                return View(imdbList);
            }
            return View();
        }
    }
}

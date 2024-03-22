using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        ISubscribeService _subscribeSubscribe;

        public SubscribeController(ISubscribeService subscribeSubscribe)
        {
            _subscribeSubscribe = subscribeSubscribe;
        }
        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeSubscribe.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSubscribe(Subscribe Subscribe)
        {
            _subscribeSubscribe.TInsert(Subscribe);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _subscribeSubscribe.TGetById(id);
            _subscribeSubscribe.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSubscribe(Subscribe Subscribe)
        {
            _subscribeSubscribe.TUpdate(Subscribe);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _subscribeSubscribe.TGetById(id);
            return Ok(values);
        }
    }
}

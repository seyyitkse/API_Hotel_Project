using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _staffService;

        public GuestController(IGuestService staffService)
        {
            _staffService = staffService;
        }
        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddGuest(Guest staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteGuest(int id)
        {
            var values = _staffService.TGetById(id);
            _staffService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateGuest(Guest staff)
        {
            _staffService.TUpdate(staff);
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetGuest(int id)
        {
            var values = _staffService.TGetById(id);
            return Ok(values);
        }
    }
}

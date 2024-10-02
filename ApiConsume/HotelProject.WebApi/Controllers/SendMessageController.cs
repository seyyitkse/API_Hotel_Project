using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }
        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage message)
        {
            _sendMessageService.TInsert(message);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteSendMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage message)
        {
            _sendMessageService.TUpdate(message);
            return NoContent();
        }
        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var values = _sendMessageService.TGetById(id);
            return Ok(values);
        }
    }
}

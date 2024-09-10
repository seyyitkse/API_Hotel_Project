using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public ReserveController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            //booking.UpdatedDate=DateTime.Now;
            //booking.CreatedDate = DateTime.Now;
            //booking.CheckOutDate = DateTime.Now;
            //booking.CheckInDate = DateTime.Now;
            //booking.Status = "Active";

            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut("UpdateReservation")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }
        [HttpPut("BookingApproved")]
        public IActionResult BookingApproved(Booking booking)
        {
            _bookingService.TBookingStatusChangeApproved(booking);
            return Ok();
        }
        [HttpPut("BookingCanceled")]
        public IActionResult BookingCanceled(Booking booking)
        {
            _bookingService.TBookingStatusChangeCanceled(booking);
            return Ok();
        }
        [HttpPut("BookingWaiting")]
        public IActionResult BookingWaiting(Booking booking)
        {
            _bookingService.TBookingStatusChangeWaiting(booking);
            return Ok();
        }
        [HttpPut("BookingCompleted")]
        public IActionResult BookingCompleted(Booking booking)
        {
            _bookingService.TBookingStatusChangeCompleted(booking);
            return Ok();
        }
        [HttpPut("BookingApprovedId")]
        public IActionResult BookingApprovedId(int id)
        {
            _bookingService.TBookingStatusChangeApprovedId(id);
            return Ok();
        }
    }
}

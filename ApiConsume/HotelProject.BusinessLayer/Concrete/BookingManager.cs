using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public void TBookingStatusChangeApproved(Booking booking)
        {
            _bookingDal.BookingStatusChangedApproved(booking);
        }

        public void TBookingStatusChangeApprovedId(int id)
        {
            _bookingDal.BookingStatusChangedApprovedId(id);
        }

        public void TBookingStatusChangeCanceled(Booking booking)
        {
            _bookingDal.BookingStatusChangedCanceled(booking);
        }

        public void TBookingStatusChangeCompleted(Booking booking)
        {
            _bookingDal.BookingStatusChangedCompleted(booking);
        }

        public void TBookingStatusChangeWaiting(Booking booking)
        {
            _bookingDal.BookingStatusChangedWaiting(booking);

        }

        public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public Booking TGetById(int id)
        {
            return _bookingDal.GetById(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TInsert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}

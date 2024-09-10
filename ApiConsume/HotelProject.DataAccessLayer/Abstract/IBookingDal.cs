using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void  BookingStatusChangedApproved(Booking booking);
        void BookingStatusChangedCanceled(Booking booking);
        void BookingStatusChangedWaiting(Booking booking);
        void BookingStatusChangedCompleted(Booking booking);
        void BookingStatusChangedApprovedId(int id);
    }
}

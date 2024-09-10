using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService:IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(Booking booking);
        void TBookingStatusChangeCanceled(Booking booking);
        void TBookingStatusChangeWaiting(Booking booking);
        void TBookingStatusChangeCompleted(Booking booking);
        void TBookingStatusChangeApprovedId(int id);
    }
}

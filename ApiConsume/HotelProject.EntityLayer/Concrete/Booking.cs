namespace HotelProject.EntityLayer.Concrete
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string SpecialRequests { get; set; }
        public string Description{ get; set; }
        public string Status{ get; set; }

    }
}

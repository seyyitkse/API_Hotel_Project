using System.ComponentModel.DataAnnotations;

namespace HotelProject.EntityLayer.Concrete
{
    public class Guest
    {
        [Key]
        public int GuestId { get; set; }
        public string GuestName { get; set; }
        public string GuestSurname { get; set; }
        public string City { get; set; }
    }
}

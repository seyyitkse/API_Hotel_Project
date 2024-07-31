using System.ComponentModel.DataAnnotations;

namespace HotelProject.EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Content1 { get; set; }
        public int RoomCount{ get; set; }
        public int StaffCount{ get; set; }
        public int CustomerCount{ get; set; }
    }
}

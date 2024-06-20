using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }
        [Required(ErrorMessage = "Service Icon is required")]
        public string? ServiceIcon { get; set; }
        [Required(ErrorMessage = "Service Title is required")]
        [StringLength(100, ErrorMessage = "Service Title must be less than 100 characters")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Service Description is required")]
        [StringLength(500, ErrorMessage = "Service Title must be less than 500 characters")]
        public string? Description { get; set; }
    }
}

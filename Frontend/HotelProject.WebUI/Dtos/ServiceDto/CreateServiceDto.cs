using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Service Icon is required")]
        public string? ServiceIcon { get; set; }
        [Required(ErrorMessage = "Service Title is required")]
        [StringLength(100, ErrorMessage = "Service Title must be less than 100 characters")]
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}

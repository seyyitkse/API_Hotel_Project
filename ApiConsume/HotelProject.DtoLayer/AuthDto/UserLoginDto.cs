using System.ComponentModel.DataAnnotations;

namespace HotelProject.DtoLayer.AuthDto
{
    public class UserLoginDto
    {
        public string Mail{ get; set; }
        public string Password { get; set; }
    }
}

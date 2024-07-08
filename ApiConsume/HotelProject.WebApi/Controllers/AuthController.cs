using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.AuthDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationUserService _userService;

        public AuthController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserAddDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.IsSuccess)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }

            return BadRequest("Invalid model");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "C:/Users/ahmet/OneDrive/Belgeler/GitHub/API_Hotel_Project/ApiConsume/HotelProject.WebApi/Images", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"https://yourdomain.com/images/{fileName}"; 

            return Ok(new { message = "File uploaded successfully", fileUrl });
        }


    }
}

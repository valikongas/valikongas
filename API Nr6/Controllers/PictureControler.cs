using API_Nr6.Object;
using Microsoft.AspNetCore.Mvc;

namespace API_Nr6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureControler : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadPicture(ImageUploadRequest file)
        {
           using var memoryStream = new MemoryStream();
            await file.Image.CopyToAsync(memoryStream);
            var fileBytes = memoryStream.ToArray();
            return Ok("File uploaded successfully.");
        }
    }
}

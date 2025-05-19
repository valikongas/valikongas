using API_Nr6.Atribute;
using Microsoft.AspNetCore.Http;

namespace API_Nr6.Object
{
    public class ImageUploadRequest
    {
        [MaxFileSize(2 * 1024 * 1024)] // 2 MB
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public required IFormFile Image { get; set; }
    }
}

using Egzaminas.CustomValidationAtributes;

namespace Egzaminas.Object
{
    public class ImageLoadRequest
    {
        [MaxFileSizeAtribute(5 * 1024 * 1024)]

        // Leistini plėtiniai: .png ir .jpg
        [AlowedExtentionAtribute(new[] { ".png", ".jpg", ".jpeg" })]
  
        public IFormFile Image { get; set; }
    }
}

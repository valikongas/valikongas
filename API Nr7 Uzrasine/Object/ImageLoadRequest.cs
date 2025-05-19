namespace API_Nr7_Uzrasine.Object
{
    public class ImageLoadRequest
    {
        // nenaudojau del Swagerio. Nes taip jis nesupranta, kad ikelti paveiksliuka


        // Maksimalus failo dydis: 5 MB (5 * 1024 * 1024 baitai)
        [MaxFileSizeAtribute(5 * 1024 * 1024)]

        // Leistini plėtiniai: .png ir .jpg
        [AlowedExtentionAtribute(new[] { ".png", ".jpg", ".jpeg" })]
        public string Tekstas { get; set; }
        public IFormFile Image { get; set; }
    }
}

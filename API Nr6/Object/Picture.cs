using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace API_Nr6.Object
{
    public class Picture
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Type { get; set; }
        public byte[] ImageData { get; set; }
        public Picture( string name, long size, string type, byte[] imagedata )
        {
            Name = name;
            Size = size;
            Type = type;
            ImageData = imagedata;
        }
    }
}

namespace FailuDB
{
    internal class Failai
    {
        public int Id   { get; set; }
        public int FolderID { get; set; }
        public string? Name { get; set; }    
        public double? Size { get; set; }
        public string? Path { get; set; }

        public Folder Folder { get; set; }

        public Failai()
        {
            
        }
    }
}


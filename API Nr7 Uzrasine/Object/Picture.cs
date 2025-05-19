namespace API_Nr7_Uzrasine.Object
{
    public class Picture
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        public MessageUzrasine Message { get; set; }
    }
}

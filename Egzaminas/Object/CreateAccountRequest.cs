namespace Egzaminas.Object
{
    public class CreateAccountRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PersonalNo { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public required ImageLoadRequest Picture { get; set; }
    }
}

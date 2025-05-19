using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Egzaminas.Object
{
    public class UserResidence
    {
        [Key, ForeignKey("UserData")]
        public int UserDataId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

 
        public UserData UserData { get; set; }
        public UserResidence()
        {
            
        }
    }
}

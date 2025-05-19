using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Egzaminas.Object
{
    public class UserData
    {

        [Key, ForeignKey("User")]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; } 


        public User User { get; set; }
        public UserResidence UserResidence { get; set; }

        public UserData()
        {
            
        }
    }
}




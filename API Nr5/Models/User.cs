using System.ComponentModel.DataAnnotations;

namespace API_Nr5.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPosition { get; set; }
        public ICollection<TaskApi>? Tasks { get; set; }

        public User(string userName, string userPosition)
        {
            UserName = userName;
            UserPosition = userPosition;
        }
    }
}

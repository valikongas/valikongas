using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API_Nr5.Models
{
    public class TaskApi
    {
        [Key]
        public int TaskApiId { get; set; }
        public string NameTask { get; set; }
        public string Status { get; set; }
        public DateTime? TaskDate { get; set; }
        public ICollection<User>? Users { get; set; }
        public TaskApi(string nameTask, string status, DateTime? taskDate)
        {
            NameTask = nameTask;
            Status = status;
            TaskDate = taskDate;
        }
    }
    

}

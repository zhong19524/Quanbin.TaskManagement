using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Fullname { get; set; }

        public string Mobileno { get; set; }

        public ICollection<Task> Tasks { get; set; }

        public ICollection<TasksHistory> TasksHistories { get; set; }
    }
}

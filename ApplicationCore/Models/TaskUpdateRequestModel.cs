using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class TaskUpdateRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task MUST be assigned to a User")]
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Priority { get; set; }
        public string Remarks { get; set; }
    }
}

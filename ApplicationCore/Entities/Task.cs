﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public string Priority { get; set; }
        public string Remarks { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}

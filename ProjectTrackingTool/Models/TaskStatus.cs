using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class TaskStatus
    {
        [Key]
        public int Status_Id { get; set; }

        public string Status_Name { get; set; }
    }
}

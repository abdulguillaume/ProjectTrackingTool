using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class TaskPriority
    {
        [Key]
        public int Priority_Id { get; set; }

        public string Priority_Name { get; set; }
    }
}

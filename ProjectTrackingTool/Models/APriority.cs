using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class APriority
    {
        [Key]
        [Required]
        [DisplayName("Priority ID")]
        public int Priority_Id { get; set; }

        [DisplayName("Priority")]
        public string Priority_Name { get; set; }

        public short cat { get; set; }
    }
}

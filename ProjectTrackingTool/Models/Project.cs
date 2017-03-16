using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Models
{
    public class Project
    {
        [Key]
        public int Project_Id { get; set; }

        [Required]
        [DisplayName("Project name")]
        public string Project_Name { get; set; }

        public string wbs { get; set; }

        public Customer Client { get; set; }

        [Required]
        [DisplayName("Start date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Start_Date { get; set; }

        [Required]
        [DisplayName("End date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime End_Date { get; set; }

        [Required]
        [DisplayName("Project description")]
        public string Project_Desc { get; set; }

        public AStatus status { get; set; }

        public APriority priority { get; set; }

        public List<ProjectTask> Tasks_List { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Models
{
    public class Project
    {
        [Key]
        public int Project_Id { get; set; }
        public string Project_Name { get; set; }

        public Customer Client { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public string Project_Desc { get; set; }

        public List<ProjectTask> Tasks_List { get; set; }
    }
}
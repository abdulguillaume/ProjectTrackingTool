using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class ContactType
    {
        [Key]
        public int Contact_Type_Id { get; set; }

        public string Contact_Type_Name { get; set; }
    }
}

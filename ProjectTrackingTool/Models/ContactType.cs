using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class ContactType
    {
        [Key]
        [DisplayName("Contact type")]
        [Required(ErrorMessage="Required")]
        public int Contact_Type_Id { get; set; }

        [DisplayName("Contact type")]
        public string Contact_Type_Name { get; set; }
    }
}

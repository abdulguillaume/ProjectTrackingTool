using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class ContactInfo
    {
        [Key]
        public int Contact_Info_Id { get; set; }

        [Required]
        public ContactType type { get; set; }//private set; }
        
        [Required]
        [DisplayName("Description")]
        public string detail { get; set; }


        internal void addContactType(ContactType contact_type_)
        {
            type = contact_type_;
        }
    }
}

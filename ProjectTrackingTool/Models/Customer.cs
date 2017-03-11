using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        [Required]
        [DisplayName("Customer name")]
        public string Customer_Name { get; set; }

        [Required]
        public CustomerType Customer_Type { get;  set; }

        [Required]
        [DisplayName("Contact name")]
        public string Contact_Name { get; set; }

        public virtual List<ContactInfo> Contact_Info { get; set;}// private set; }

        internal void addCustomerType(CustomerType customer_type)
        {
            Customer_Type = customer_type;
        }

        internal void addContactInfo(List<ContactInfo> info)
        {
            if (Contact_Info == null)
                Contact_Info = info;
            else
                Contact_Info.AddRange(info);
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectTrackingTool.Models
{
    public class Customer
    {
        [Key]
        public int Customer_Id { get; set; }

        public string Customer_Name { get; set; }

        public CustomerType Customer_Type { get;  set; }

        public string Contact_Name { get; set; }

        public virtual List<ContactInfo> Contact_Info { get; private set; }

        internal void addCustomerType(CustomerType customer_type)
        {
            Customer_Type = customer_type;
        }

        internal void addContactInfo(List<ContactInfo> info)
        {
            Contact_Info = info;
        }
    }
}
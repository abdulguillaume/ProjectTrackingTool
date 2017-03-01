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

        public CustomerType Customer_Type { get; set; }

        public string Contact_Name { get; set; }

        public List<ContactType> Contact_Type { get; set; }


    }
}
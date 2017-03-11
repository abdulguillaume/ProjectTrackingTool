using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class CustomerType
    {
        [Key]
        [DisplayName("Customer type")]
        public int Customer_Type_Id { get; set; }

        [DisplayName("Customer type")]
        public string Customer_Type_Name { get; set; }
    }
}

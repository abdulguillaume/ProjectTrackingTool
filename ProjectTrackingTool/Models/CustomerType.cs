using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ProjectTrackingTool.Models
{
    public class CustomerType
    {
        [Key]
        public int Customer_Type_Id { get; set; }
        public string Customer_Type_Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Contact ID")]
        public int ContactID { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }

        [DisplayName("Payment Information ID")]
        public string PayInfoID { get; set; }
        public virtual PayInfo PayInfo { get; set; }

        [DisplayName("Running Balance")]
        public double RunningBalance { get; set; }
    }
}
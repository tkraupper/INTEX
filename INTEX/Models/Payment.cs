using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Payment")]
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }

        public double Amount { get; set; }

        public string Date { get; set; }
    }
}
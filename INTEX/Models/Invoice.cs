using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        public int WorkOrderID { get; set; }

        public string DueDate { get; set; }

        public string EarlyPaymentDate { get; set; }

        public double EarlyPaymentDiscount { get; set; }
    }
}
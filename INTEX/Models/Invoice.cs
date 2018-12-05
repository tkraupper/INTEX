using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Invoice ID")]
        public int InvoiceID { get; set; }

        [ForeignKey("WorkOrder")]
        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        [DisplayName("Date Due")]
        public string DueDate { get; set; }

        [DisplayName("Early Payment Date")]
        public string EarlyPaymentDate { get; set; }

        [DisplayName("Early Payment Discount")]
        public double EarlyPaymentDiscount { get; set; }
    }
}
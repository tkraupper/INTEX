using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("PriceChange")]
    public class PriceChange
    {
        [Key]
        [DisplayName("Price Change ID")]
        public int PriceChangeID { get; set; }

        [ForeignKey("WorkOrder")]
        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        public double Amount { get; set; }

        public string Reason { get; set; }

        public string Date { get; set; }
    }
}
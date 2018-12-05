using System;
using System.Collections.Generic;
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
        public int PriceChangeID { get; set; }

        [ForeignKey("WorkOrder")]
        public int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        public double Amount { get; set; }

        public string Reason { get; set; }

        public string Date { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
        public int WorkOrderID { get; set; }

        [ForeignKey("Quote")]
        public int QuoteID { get; set; }
        public virtual Quote Quote { get; set; }

        public string ConfirmationSentDate { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [ForeignKey("ContactInfo")]
        public int ContactID { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }

        [ForeignKey("PayInfo")]
        public int PayInfoID { get; set; }
        public virtual PayInfo PayInfo { get; set; }

        public string Comments { get; set; }

        public string SummaryReport { get; set; }
    }
}
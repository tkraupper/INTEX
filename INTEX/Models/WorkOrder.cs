using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Work Order ID")]
        public int WorkOrderID { get; set; }

        [DisplayName("Quote ID")]
        public int QuoteID { get; set; }
        public virtual Quote Quote { get; set; }

        [DisplayName("Confirmation Date")]
        public string ConfirmationSentDate { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public int ContactID { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }

        public int PayInfoID { get; set; }
        public virtual PayInfo PayInfo { get; set; }

        public string Comments { get; set; }

        [DisplayName("Summary Report")]
        public string SummaryReport { get; set; }

        public virtual ICollection<Sample> Sample { get; set; }
    }
}
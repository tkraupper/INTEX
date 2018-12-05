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

        public int QuoteID { get; set; }
        public virtual Quote Quote { get; set; }

        public string ConfirmationSentDate { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public int ContactID { get; set; }
        public virtual ContactInfo ContactInfo { get; set; }

        public int PayInfoID { get; set; }
        public virtual PayInfo PayInfo { get; set; }

        public string Comments { get; set; }

        public string SummaryReport { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("QuoteRequest")]
    public class QuoteRequest
    {
        [Key]
        [DisplayName("Quote Request ID")]
        public int QuoteRequestID { get; set; }

        [ForeignKey("Customer")]
        [DisplayName("Customer ID")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<AssayRequest> AssayRequests { get; set; }

        public virtual Quote Quote { get; set; }
    }
}
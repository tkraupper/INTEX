using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Quote")]
    public class Quote
    {
        [Key]
        [DisplayName("Quote ID")]
        public int QuoteID { get; set; }

        [ForeignKey("QuoteRequest")]
        [DisplayName("Quote Request ID")]
        public int QuoteRequestID { get; set; }
        public virtual QuoteRequest QuoteRequest { get; set; }

        [DisplayName("Quoted Amount")]
        public double QuotedAmount { get; set; }
    }
}
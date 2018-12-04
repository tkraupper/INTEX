using System;
using System.Collections.Generic;
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
        public int QuoteID { get; set; }

        public int QuoteRequestID { get; set; }

        public double QuotedAmount { get; set; }
    }
}
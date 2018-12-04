using System;
using System.Collections.Generic;
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
        public int QuoteRequestID { get; set; }

        public int CustomerID { get; set; }
    }
}
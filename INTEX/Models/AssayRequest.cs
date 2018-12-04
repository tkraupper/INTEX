using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("AssayRequest")]
    public class AssayRequest
    {
        [Key]
        public int QuoteRequestID { get; set; }

        public int LTNumber { get; set; }

        public int AssayID { get; set; }
    }
}
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
        [Key, Column(Order = 0)]
        public int QuoteRequestID { get; set; }
        public virtual QuoteRequest QuoteRequest { get; set; }

        [Key, Column(Order = 1)]
        public int LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        [Key, Column(Order = 2)]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }
    }
}
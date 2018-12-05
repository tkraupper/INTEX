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

        [Key]
        [ForeignKey("Compound")]
        public int LTNumber { get; set; }
        public virtual Compound Compound { get; set; }

        [Key]
        [ForeignKey("Assay")]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }
    }
}
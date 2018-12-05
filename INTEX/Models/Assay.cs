using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        public int AssayID { get; set; }

        public string AssayName { get; set; }

        public string AssayDetails { get; set; }

        public double? TimeEstimate { get; set; }

        public string LiteratureReferences { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Assay ID")]
        public int AssayID { get; set; }

        [DisplayName("Assay Name")]
        public string AssayName { get; set; }

        [DisplayName("Assay Details")]
        public string AssayDetails { get; set; }

        [DisplayName("Time Estimate")]
        public string TimeEstimate { get; set; }

        [DisplayName("Literature References")]
        public string LiteratureReferences { get; set; }
    }
}
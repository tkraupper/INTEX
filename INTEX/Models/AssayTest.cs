using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("AssayTest")]
    public class AssayTest
    {
        [Key, Column(Order = 0)]
        [DisplayName("Assay ID")]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Test ID")]
        public int TestID { get; set; }
        public virtual Test Test { get; set; }

        [DisplayName("Conditional")]
        public bool Conditional { get; set; }
    }
}
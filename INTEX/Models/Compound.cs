using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Compound")]
    public class Compound
    {
        [Key]
        [DisplayName("LT Number")]
        public int LTNumber { get; set; }

        [DisplayName("Compound Name")]
        public string CompoundName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        [DisplayName("Material ID")]
        public int MaterialID { get; set; }

        [DisplayName("Name")]
        public string MaterialName { get; set; }

        [DisplayName("Cost")]
        public double MaterialCost { get; set; }
    }
}
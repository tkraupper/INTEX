using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        [DisplayName("Test ID")]
        public int TestID { get; set; }

        [DisplayName("Description")]
        public string TestDescription { get; set; }

        [DisplayName("Cost")]
        public decimal TestCost { get; set; }

        [DisplayName("Base Price")]
        public decimal BasePrice { get; set; }

        public virtual ICollection<TestMaterial> TestMaterial { get; set; }
    }
}
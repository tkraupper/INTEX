using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("PayInfo")]
    public class PayInfo
    {
        [Key]
        public int PayInfoID { get; set; }

        public string Card { get; set; }

        public string ExpDate { get; set; }

        public int SecurityCode { get; set; }
    }
}
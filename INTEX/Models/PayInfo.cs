using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Payment Information ID")]
        public int PayInfoID { get; set; }

        [DisplayName("Card Number")]
        public string Card { get; set; }

        [DisplayName("Expiration Date")]
        public string ExpDate { get; set; }

        [DisplayName("Security Code")]
        public int SecurityCode { get; set; }
    }
}
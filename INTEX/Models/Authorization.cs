using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Authorization")]
    public class Authorization
    {
        [Key]
        [DisplayName("Authorization ID")]
        public int AuthID { get; set; }

        [DisplayName("Authorization Type")]
        public string AuthType { get; set; }
    }
}
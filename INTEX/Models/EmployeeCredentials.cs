using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("EmployeeCredentials")]
    public class EmployeeCredentials
    {
        [Key]
        public string EmployeeID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [ForeignKey("Authorization")]
        public int AuthID { get; set; }
        public virtual Authorization Authorization { get; set; }
    }
}
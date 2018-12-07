using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Employee ID")]
        public int EmployeeID { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Authorization ID")]
        public int AuthID { get; set; }
        public virtual Authorization Authorization { get; set; }
    }
}
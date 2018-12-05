using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("ContactInfo")]
    public class ContactInfo
    {
        [Key]
        [DisplayName("Contact ID")]
        public int ContactID { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [DisplayName("ZIP Code")]
        public string ZIP { get; set; }

        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [DisplayName("Email Address")]
        public string Email { get; set; }
    }
}
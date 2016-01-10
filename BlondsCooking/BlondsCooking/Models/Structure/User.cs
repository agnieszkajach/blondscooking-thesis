using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlondsCooking.Models.Structure
{
    [Table("Users")]
    public class User
    {
        [Key]
        public string IdSecure { get; set; }

        public string Email { get; set; }

        public double SpicyPreference { get; set; }

        public double SaltyPreference { get; set; }

        public double BitterPreference { get; set; }

        public double SweetPreference { get; set; }

        public double MeatPreference { get; set; }

        public double SourPreference { get; set; }
    }
}
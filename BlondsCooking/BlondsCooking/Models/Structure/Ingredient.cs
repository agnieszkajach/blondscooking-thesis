using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlondsCooking.Models.Structure
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
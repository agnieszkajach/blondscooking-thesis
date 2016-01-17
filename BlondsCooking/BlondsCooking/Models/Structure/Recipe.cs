using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlondsCooking.Models.Structure
{
    [Table("Recipes")]
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Ingredients { get; set; }

        public string Temperature { get; set; }

        public string Time { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Image { get; set; }

        public double SpicyValue { get; set; }

        public double SaltyValue { get; set; }

        public double BitterValue { get; set; }

        public double SweetValue { get; set; }

        public double MeatValue { get; set; }

        public double SourValue { get; set; }

        public string IngredientsVector { get; set; }
    }
}
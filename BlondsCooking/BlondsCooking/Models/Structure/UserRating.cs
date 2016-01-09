using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlondsCooking.Models.Structure
{
    [Table("UserRatings")]
    public class UserRating
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public double Score { get; set; }
    }
}
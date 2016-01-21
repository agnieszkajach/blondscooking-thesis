using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Db;

namespace BlondsCooking.Models
{
    public class IngredientMatchViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double MatchValue { get; set; }

        public string MatchingIconUrl { get; set; }

        public IngredientMatchViewModel(string name, double matchValue)
        {
            Name = name;
            MatchValue = matchValue;
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                Id =
                    context.Ingredients.Where(ingredient => ingredient.Name.CompareTo(Name) == 0)
                        .Select(ingredient => ingredient.Id)
                        .FirstOrDefault();
            }
            if (MatchValue >= 0.3)
            {
                MatchingIconUrl = "git";
            }
            else if (MatchValue < 0.3 && MatchValue >= 0.1)
            {
                MatchingIconUrl = "soso";
            }
            else
            {
                MatchingIconUrl = "bad";
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Db;

namespace BlondsCooking.Helpers
{
    public class IngredientsHelper
    {
        public List<string> GetUniqueIngredients(BlondsCookingContext context)
        {
            List<string> uniqueIngredients = new List<string>();
            foreach (var recipe in context.Recipes)
            {
                var ingredientsVector = recipe.IngredientsVector;
                List<string> ingredients = ingredientsVector.Split(',').ToList();
                foreach (var ingredient in ingredients)
                {
                    if (!uniqueIngredients.Contains(ingredient))
                    {
                        uniqueIngredients.Add(ingredient);
                    }
                }

            }
            return uniqueIngredients;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Statistics
{
    public class IngredientsPairingHelper
    {
        public Dictionary<string, double> CalculatePercentagePairingForIngredient(List<string> selectedIngredients)
        {
            Dictionary<string, double> percentagePairing = new Dictionary<string, double>();
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                List<Ingredient> ingredientsExceptSelected = context.Ingredients.Where(ingredient => !selectedIngredients.Contains(ingredient.Name)).ToList();
                List<Recipe> recipesWithSelectedIngredients =
                    context.Recipes.Where(
                        recipe => selectedIngredients.All(ingredient => recipe.IngredientsVector.Contains(ingredient)))
                        .ToList();
                foreach (var ingredient in ingredientsExceptSelected)
                {
                    var recipesWithAllIngredients =
                        recipesWithSelectedIngredients.Where(
                            recipe => recipe.IngredientsVector.Contains(ingredient.Name)).ToList();
                    double percentagePairingValue = (double)recipesWithAllIngredients.Count/recipesWithSelectedIngredients.Count;
                    percentagePairing.Add(ingredient.Name, percentagePairingValue);
                }
            }
            return percentagePairing;
        }
    }
}
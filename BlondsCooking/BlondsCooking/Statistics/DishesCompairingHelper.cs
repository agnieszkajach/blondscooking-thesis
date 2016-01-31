using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.LinearRegressionModel;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Statistics
{
    public class DishesCompairingHelper
    {
        public List<Recipe> GetTopThreeMostSimilarDishes(Recipe selectedRecipe)
        {
            List<Recipe> threeMostSimilarDishes = new List<Recipe>();
            Dictionary<int, double> recipeAndSimilarityValue = new Dictionary<int, double>();
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                List<Recipe> othersRecipes = context.Recipes.Where(recipe => recipe.Id != selectedRecipe.Id).ToList();
                foreach (var otherRecipe in othersRecipes)
                {
                    var spicyDistance = Math.Pow((otherRecipe.SpicyValue - selectedRecipe.SpicyValue), 2);
                    var saltyDistance = Math.Pow((otherRecipe.SaltyValue - selectedRecipe.SaltyValue), 2);
                    var bitterDistance = Math.Pow((otherRecipe.BitterValue - selectedRecipe.BitterValue), 2);
                    var sweetDistance = Math.Pow((otherRecipe.SweetValue - selectedRecipe.SweetValue), 2);
                    var meatDistance = Math.Pow((otherRecipe.MeatValue - selectedRecipe.MeatValue), 2);
                    var sourDistance = Math.Pow((otherRecipe.SourValue - selectedRecipe.SourValue), 2);
                    var wholeDistance =
                        Math.Sqrt(spicyDistance + saltyDistance + bitterDistance + sweetDistance + meatDistance +
                                  sourDistance);
                    recipeAndSimilarityValue.Add(otherRecipe.Id, wholeDistance);
                }
                var sortedRecipes = recipeAndSimilarityValue.OrderBy(x => x.Value);
                var selectedRecipes = sortedRecipes.Take(3).Select(x => x.Key);
                threeMostSimilarDishes = new List<Recipe>(context.Recipes.Where(recipe => selectedRecipes.Contains(recipe.Id)).ToList());
            }
            return threeMostSimilarDishes;
        }
    }
}
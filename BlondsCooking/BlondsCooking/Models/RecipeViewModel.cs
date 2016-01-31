using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Models
{
    public class RecipeViewModel
    {
        public RecipeRateViewModel RecipeRateViewModel { get; set; }

        public List<Recipe> SimilarRecipes { get; set; }

        public RecipeViewModel(RecipeRateViewModel recipeRateViewModel, List<Recipe> similarRecipes)
        {
            RecipeRateViewModel = recipeRateViewModel;
            SimilarRecipes = new List<Recipe>(similarRecipes);
        } 
    }
}
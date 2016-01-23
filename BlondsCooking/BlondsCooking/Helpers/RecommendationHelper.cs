using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.LinearRegression;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.LinearRegressionModel;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Helpers
{
    public class RecommendationHelper
    {
        public readonly int MinimumNumberOfRates = 10;
        public bool CanGetRecommendation(string userId)
        {
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                var countOfRates = context.UserRatings.Count(rating => rating.UserId.CompareTo(userId) == 0);
                if (countOfRates > MinimumNumberOfRates)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool CanRecalculateUserParameters(string userId)
        {
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                var countOfRates = context.UserRatings.Count(rating => rating.UserId.CompareTo(userId) == 0);
                if (countOfRates > MinimumNumberOfRates)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<Rating> GetRatesAndParametersOfDishesRatedByUser(string userId)
        {
            List<Rating> ratesAndParametersOfDishesRatedByUser = new List<Rating>();
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                List<int> dishesId = context.UserRatings.Where(rating => rating.UserId.CompareTo(userId) == 0).Select(rating => rating.RecipeId).ToList();
                foreach (var dishId in dishesId)
                {
                    Rating newRating = new Rating();
                    newRating.DishParameters = new double[]
                    {
                        context.Recipes.Where(dish => dish.Id == dishId).Select(dish => dish.SpicyValue).FirstOrDefault(),
                        context.Recipes.Where(dish => dish.Id == dishId).Select(dish => dish.SaltyValue).FirstOrDefault(),
                        context.Recipes.Where(dish => dish.Id == dishId).Select(dish => dish.BitterValue).FirstOrDefault(),
                        context.Recipes.Where(dish => dish.Id == dishId).Select(dish => dish.SweetValue).FirstOrDefault(),
                        context.Recipes.Where(dish => dish.Id == dishId).Select(dish => dish.MeatValue).FirstOrDefault(),
                        context.Recipes.Where(dish => dish.Id == dishId).Select(dish => dish.SourValue).FirstOrDefault()
                    };
                    newRating.DishId = dishId;
                    newRating.Rate = context.UserRatings.Where(
                        rating => rating.RecipeId == dishId && rating.UserId.CompareTo(userId) == 0)
                        .Select(rating => rating.Rate)
                        .FirstOrDefault();
                    newRating.UserId = userId;
                    ratesAndParametersOfDishesRatedByUser.Add(newRating);
                }
            }
            return ratesAndParametersOfDishesRatedByUser;
        }

        private List<Dish> GetDishesUnratedByUser(string userId)
        {
            List<Dish> dishesUnratedByUser = new List<Dish>();
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                var ratedDishesId = context.UserRatings.Where(rating => rating.UserId.CompareTo(userId) == 0).Select(rating => rating.RecipeId).ToList();
                var unratedDishes = context.Recipes.Where(recipe => !ratedDishesId.Contains(recipe.Id)).ToList();
                foreach (var unratedDish in unratedDishes)
                {
                    dishesUnratedByUser.Add(new Dish()
                    {
                        DishId = unratedDish.Id,
                        DishParameters = new double[]
                        {
                            unratedDish.SpicyValue,
                            unratedDish.SaltyValue,
                            unratedDish.BitterValue,
                            unratedDish.SweetValue,
                            unratedDish.MeatValue,
                            unratedDish.SourValue
                        }
                    });
                }
            }
            return dishesUnratedByUser;
        } 

        public List<Recipe> GetRecommendedRecipesForUser(string userId)
        {
            List<Recipe> recommendedRecipesForUser = new List<Recipe>();
            RecommendedDishesHelper helper = new RecommendedDishesHelper();
            var ratesAndParametersOfDishesRatedByUser = GetRatesAndParametersOfDishesRatedByUser(userId);
            var dishesUnratedByUser = GetDishesUnratedByUser(userId);
            var recommendedDishes = helper.CalculatePredictedRateForUnratedDishes(ratesAndParametersOfDishesRatedByUser, dishesUnratedByUser);
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                foreach (var recommendedDish in recommendedDishes)
                {
                    var recipeBd = context.Recipes.Where(recipe => recipe.Id == recommendedDish.DishId).FirstOrDefault();
                    recommendedRecipesForUser.Add(recipeBd);
                }
            }
            return recommendedRecipesForUser;
        } 

        public void UpdateUsersParameters(double[] parameters)
        {
            
        }
    }
}
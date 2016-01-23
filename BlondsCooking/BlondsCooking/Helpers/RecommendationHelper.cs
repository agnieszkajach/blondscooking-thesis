using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.LinearRegressionModel;

namespace BlondsCooking.Helpers
{
    public class RecommendationHelper
    {
        public bool CanGetRecommendation(string userId)
        {
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                var countOfRates = context.UserRatings.Count(rating => rating.UserId.CompareTo(userId) == 0);
                if (countOfRates > 5)
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
                if (countOfRates > 5)
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

        public void UpdateUsersParameters(double[] parameters)
        {
            
        }
    }
}
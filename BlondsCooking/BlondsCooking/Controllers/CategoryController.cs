using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using BlondsCooking.Helpers;
using BlondsCooking.LinearRegression;
using BlondsCooking.Models;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.Structure;
using Microsoft.AspNet.Identity;

namespace BlondsCooking.Controllers
{
    public class CategoryController : Controller
    {
        private BlondsCookingContext context;
        private RecipeRateViewModel model;
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipe(int id = 1)
        {
            context = new BlondsCookingContext();
            Recipe recipeModel = context.Recipes.FirstOrDefault(recipe => recipe.Id == id);
            if (recipeModel == null)
            {
                return View("Error");
            }
            model = new RecipeRateViewModel()
            {
                Id = recipeModel.Id,
                Name = recipeModel.Name,
                Description = recipeModel.Description,
                Image = recipeModel.Image,
                Ingredients = recipeModel.Ingredients,
                Temperature = recipeModel.Temperature,
                Time = recipeModel.Time
            };
            return View(model);
        }

        [HttpPost]
        public JsonResult Rate(int id, int rateValue)
        {
            RecommendationHelper helper = new RecommendationHelper();
            if (id != 0)
            {
                using (BlondsCookingContext context = new BlondsCookingContext())
                {
                    context.UserRatings.Add(new UserRating()
                    {
                        RecipeId = id,
                        Rate = rateValue,
                        UserId = User.Identity.GetUserId()
                    });
                    context.SaveChanges();
                } 
            }
            if (helper.CanRecalculateUserParameters(User.Identity.GetUserId()))
            {
                RecommendationHelper recommendationHelper = new RecommendationHelper();
                var ratesAndParametersOfDishesRatedByUser =
                    recommendationHelper.GetRatesAndParametersOfDishesRatedByUser(User.Identity.GetUserId());
                UserParametersHelper userParametersHelper = new UserParametersHelper();
                userParametersHelper.CalculateParametersForUser(ratesAndParametersOfDishesRatedByUser);
            }
            return Json(id);
        }
    }
}
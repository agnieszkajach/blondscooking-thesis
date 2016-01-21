using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlondsCooking.Helpers;
using BlondsCooking.Models;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.Requests;
using BlondsCooking.Models.Structure;
using BlondsCooking.Statistics;
using Microsoft.AspNet.Identity;

namespace BlondsCooking.Controllers
{
    public class HomeController : Controller
    {
        private IBlondsCookingContext context;

        public HomeController()
        {
            this.context = new BlondsCookingContext();
        }

        public HomeController(IBlondsCookingContext context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Category(int id = 2)
        {
            context = new BlondsCookingContext();
            IEnumerable<Recipe> model = context.Query<Recipe>().Where(recipe => recipe.CategoryId == id);
            if (context.Query<Category>().FirstOrDefault(category => category.Id == id) == null)
            {
                return View("Error");
            }
            return View(model);
        }
        
        [Authorize]
        public ActionResult Recommendation()
        {
            RecommendationHelper helper = new RecommendationHelper();
            if (helper.CanGetRecommendation(User.Identity.GetUserId()))
            {
                return View();
            }
            return View("NotEnoughRates");
        }

        public ActionResult FoodPairing()
        {
            return View();
        }

   
        public JsonResult GetIngredients(int id = 0)
        {
            using (BlondsCookingContext context = new BlondsCookingContext())
            {
                var result = context.Ingredients.ToList();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetMatchingIngredients(List<int> listOfIds)
        {
            if (listOfIds == null || listOfIds.Count == 0)
            {
                using (BlondsCookingContext context = new BlondsCookingContext())
                {
                    var result = context.Ingredients.ToList();
                    return Json(result);
                }
            }
            else
            {
                using (BlondsCookingContext context = new BlondsCookingContext())
                {
                    List<string> ingredientsList =
                        context.Ingredients.Where(ingrdient => listOfIds.Contains(ingrdient.Id))
                            .Select(ingredient => ingredient.Name)
                            .ToList();

                    IngredientsPairingHelper pairingHelper = new IngredientsPairingHelper();
                    var pairedIngredients = pairingHelper.CalculatePercentagePairingForIngredient(ingredientsList);
                    var pairedIngredientsSorted = from pair in pairedIngredients orderby pair.Value descending select pair;
                    List<IngredientMatchViewModel> result = new List<IngredientMatchViewModel>();
                    foreach (var pairedIngredient in pairedIngredientsSorted)
                    {
                        result.Add(new IngredientMatchViewModel(pairedIngredient.Key, pairedIngredient.Value));
                    }
                    return Json(result);
                }
            }
            
        }


        protected override void Dispose(bool disposing)
        {
            if (context != null)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
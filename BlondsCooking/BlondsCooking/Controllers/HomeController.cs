using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Controllers
{
    public class HomeController : Controller
    {
        private BlondsCookingContext context;
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
            IEnumerable<Recipe> model = context.Recipes.Where(recipe => recipe.CategoryId == id);
            return View(model);
        }
    }
}
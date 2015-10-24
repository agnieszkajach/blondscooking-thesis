using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Controllers
{
    public class CategoryController : Controller
    {
        private BlondsCookingContext context;
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipe(int id = 1)
        {
            context = new BlondsCookingContext();
            Recipe model = context.Recipes.FirstOrDefault(recipe => recipe.Id == id);
            return View(model);
        }
    }
}
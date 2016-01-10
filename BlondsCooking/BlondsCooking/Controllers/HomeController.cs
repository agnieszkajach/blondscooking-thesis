﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlondsCooking.Helpers;
using BlondsCooking.Models.Db;
using BlondsCooking.Models.Structure;
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
        
        public ActionResult Recommendation()
        {
            RecommendationHelper helper = new RecommendationHelper();
            if (helper.CanGetRecommendation(User.Identity.GetUserId()))
            {
                return View();
            }
            return View("NotEnoughRates");
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlondsCooking.Models.Structure;

namespace BlondsCooking.Models
{
    public class RecipeRateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Temperature { get; set; }

        public string Time { get; set; }

        public int? Rate { get; set; }

        public SelectList RatesList { get; set; }

        public RecipeRateViewModel()
        {
            List<int> rates = new List<int> { 0, 1, 2, 3, 4, 5 };
            RatesList = new SelectList(rates);
        }

    }
}
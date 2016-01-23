using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlondsCooking.Models.LinearRegressionModel
{
    public class Dish
    {
        public int DishId { get; set; }

        public double[] DishParameters { get; set; }

        public double PredictedRate { get; set; }
    }
}
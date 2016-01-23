using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Models.Regression.Linear;
using Accord.Statistics.Testing;
using BlondsCooking.Models;
using BlondsCooking.Models.LinearRegressionModel;

namespace BlondsCooking.LinearRegression
{
    public class RecommendedDishesHelper
    {
        public List<Dish> CalculatePredictedRateForUnratedDishes(List<Rating> rates, List<Dish> unratedDishes)
        {
            List<Dish> recommendeDishes = new List<Dish>();
            double[][] inputs = new double[rates.Count][];
            double[][] outputs = new double[rates.Count][];
            for (int i = 0; i < rates.Count; i++)
            {
                inputs[i] = rates[i].DishParameters;
                outputs[i] = new double[] {rates[i].Rate};
            }

            MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);
            double errorRegression = regression.Regress(inputs, outputs);

            foreach (var unratedDish in unratedDishes)
            {
                unratedDish.PredictedRate = regression.Compute(unratedDish.DishParameters)[0];
            }

            recommendeDishes.AddRange(unratedDishes.OrderByDescending(dish => dish.PredictedRate).ToList().Take(3));

            return recommendeDishes;
        }
    }
}

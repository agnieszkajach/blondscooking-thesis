using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Models.Regression.Linear;
using BlondsCooking.Models.LinearRegressionModel;

namespace BlondsCooking.LinearRegression
{
    public class UserParametersHelper
    {
        public double[] CalculateParametersForUser(List<Rating> ratesAndParametersOfDishesRatedByUser)
        {
            double[][] inputs = new double[ratesAndParametersOfDishesRatedByUser.Count][];
            double[][] outputs = new double[ratesAndParametersOfDishesRatedByUser.Count][];
            for (int i = 0; i < ratesAndParametersOfDishesRatedByUser.Count; i++)
            {
                inputs[i] = ratesAndParametersOfDishesRatedByUser[i].DishParameters;
            }
            for (int i = 0; i < ratesAndParametersOfDishesRatedByUser.Count; i++)
            {
                outputs[i] = new double[] { ratesAndParametersOfDishesRatedByUser[i].Rate};
            }

            MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);

            double errorRegression = regression.Regress(inputs, outputs);
            double[] coef = new double[6];
            for (int k = 0; k < regression.Coefficients.Length; k++)
            {
                coef[k] = regression.Coefficients[k, 0];
            }
            return coef;
        }
    }
}

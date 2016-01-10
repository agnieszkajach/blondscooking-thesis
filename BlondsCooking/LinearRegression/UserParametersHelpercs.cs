using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Models.Regression.Linear;

namespace LinearRegression
{
    public class UserParametersHelper
    {
        public double[] CalculateParametersForUser(List<double[]> dishesParameters, List<double> rates)
        {
            double[][] inputs = new double[dishesParameters.Count][];
            double[][] outputs = new double[rates.Count][];
            for (int i = 0; i < dishesParameters.Count; i++)
            {
                inputs[i] = dishesParameters[i];
            }
            for (int i = 0; i < rates.Count; i++)
            {
                outputs[i] = new double[] {rates[i]};
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

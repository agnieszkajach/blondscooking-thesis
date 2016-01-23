using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Models.Regression.Linear;
using BlondsCooking.Helpers;

namespace BlondsCooking.LinearRegression
{
    public class DishParametersHelper
    {
        public string PathToFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\LinearRegression\\bin\\Debug\\meal_0.csv";
        public string PathToLogFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\LinearRegression\\bin\\Debug\\log.txt";
        public List<double[]> CalculateParameterForDishes()
        {
            double global = 0.0;
            List<double[]> coefficients = new List<double[]>();
            FileHelper fileHelper = new FileHelper();
            using (StreamWriter writer = File.AppendText(PathToLogFile)) 
            {
                for (int i = 0; i < 25; i++)
                {
                    double sum = 0.0;
                    writer.WriteLine("Meal {0}", i);
                    var values = fileHelper.ReadFromFile(PathToFile);

                    double[][] inputs = values.Item1.Take(20).ToArray();

                    double[][] outputs = values.Item2.Take(20).ToArray();

                    MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);

                    double errorRegression = regression.Regress(inputs, outputs);
                    for (int j = 20; j < 27; j++)
                    {
                        var actual = regression.Compute(values.Item1[j]);
                        var error = Math.Abs(values.Item2[j][0] - actual[0]);
                        sum += error;
                        global += error;
                        writer.WriteLine("Actual {0}, {3}, Expected {1}, Error {2}, {4}", Math.Round(actual[0]), Math.Round(values.Item2[j][0]), Math.Round(error), actual[0], error);
                    }
                    double average = sum / 7;
                    writer.WriteLine("Average error: {0}", average);
                    double[] coef = new double[6];
                    for (int k = 0; k < regression.Coefficients.Length; k++)
                    {
                        writer.WriteLine("x_{0} = {1} ; ", k, regression.Coefficients[k,0]);
                        coef[k] = regression.Coefficients[k, 0];
                    }
                    writer.WriteLine();
                    coefficients.Add(coef);

                    PathToFile = PathToFile.Replace(i.ToString(), (i + 1).ToString());
                }
                double globalError = global/175;
                writer.WriteLine("Global {0}", globalError);
            }
            return coefficients;         
        }

    }
}

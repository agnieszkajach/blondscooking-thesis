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
        private const int NumberOfUsers = 27;
        private const int NumberOfUsersToLearn = 20;
        private const int NumberOfUsersToTest = 7;
        private const int NumberOfRecipes = 25;
        private const int NumberOfRecipesToLearn = 20;
        private const int NumberOfRecipesToTest = 5;
        private const int NumberOfLearningIteration = 100;
        private string PathToLogFile = AppDomain.CurrentDomain.BaseDirectory + "bin\\log.txt";

        public List<double[]> CalculateParameterForDishes()
        {
            double globalRecipeErrorSum = 0.0;
            double globalUserErrorSum = 0.0;
            double globalError;
            List<double[]> coefficients = new List<double[]>();
            FileHelper fileHelper = new FileHelper();
            double[][] inputs = new double[1][];
            double[][] outputs = new double[1][];


            using (StreamWriter writer = File.AppendText(PathToLogFile))
            {
                
                for (int k = 0; k < NumberOfLearningIteration; k++)
                {
                    globalRecipeErrorSum = 0.0;
                    globalUserErrorSum = 0.0;
                    inputs = new double[NumberOfUsers][];
                    outputs = new double[NumberOfUsers][];
                    if (coefficients.Count == 0)
                    {
                        inputs = fileHelper.GetAllUsersPreferences();
                    }
                    else
                    {
                        for (int j = 0; j < coefficients.Count; j++)
                        {
                            inputs[j] = coefficients[j];
                        }
                        coefficients = new List<double[]>();
                    }

                    for (int i = 0; i < NumberOfRecipes; i++)
                    {
                        double sum = 0.0;
                        //writer.WriteLine("Meal {0}", i);
                        outputs = fileHelper.GetAllUsersRatesForOneDish(i);
                        MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);
                        double errorRegression = regression.Regress(inputs.Take(NumberOfUsersToLearn).ToArray(), outputs.Take(NumberOfUsersToLearn).ToArray());
                        for (int j = NumberOfUsersToLearn; j < NumberOfUsers; j++)
                        {
                            var actual = regression.Compute(inputs[j]);
                            var error = Math.Abs(outputs[j][0] - actual[0]);
                            //sum += error;
                            globalRecipeErrorSum += error;
                            //writer.WriteLine("Actual {0}, {3}, Expected {1}, Error {2}, {4}", Math.Round(actual[0]), Math.Round(outputs[j][0]), Math.Round(error), actual[0], error);
                        }
                        //double average = sum / 7;
                        //writer.WriteLine("Average error: {0}", average);
                        double[] coef = new double[6];
                        for (int l = 0; l < regression.Coefficients.Length; l++)
                        {
                            //writer.WriteLine("x_{0} = {1} ; ", k, regression.Coefficients[k, 0]);
                            coef[l] = regression.Coefficients[l, 0];
                        }
                        //writer.WriteLine();
                        coefficients.Add(coef);
                    }

                    globalError = globalRecipeErrorSum / 175;
                    writer.WriteLine("{1} iteration: Global per recipe {0}", globalError, k);

                    inputs = new double[NumberOfRecipes][];
                    outputs = new double[NumberOfRecipes][];

                    for (int j = 0; j < coefficients.Count; j++)
                    {
                        inputs[j] = coefficients[j];
                    }
                    coefficients = new List<double[]>();
                    for (int i = 0; i < NumberOfUsers; i++)
                    {                        
                        outputs = fileHelper.GetUserRatesOfAllDishes(i);
                        MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);
                        double errorRegression = regression.Regress(inputs.Take(NumberOfRecipesToLearn).ToArray(), outputs.Take(NumberOfRecipesToLearn).ToArray());
                        for (int j = NumberOfRecipesToLearn; j < NumberOfRecipes; j++)
                        {
                            var actual = regression.Compute(inputs[j]);
                            var error = Math.Abs(outputs[j][0] - actual[0]);
                            globalUserErrorSum += error;
                        }
                        double[] coef = new double[6];
                        for (int l = 0; l < regression.Coefficients.Length; l++)
                        {
                            coef[l] = regression.Coefficients[l, 0];
                        }
                        coefficients.Add(coef);
                    }
                    globalError = globalUserErrorSum / 175;
                    writer.WriteLine("{1} iteration: Global per user {0}", globalError, k);
                }

                inputs = new double[NumberOfUsers][];
                outputs = new double[NumberOfUsers][];
                for (int j = 0; j < coefficients.Count; j++)
                {
                    inputs[j] = coefficients[j];
                }
                coefficients = new List<double[]>();
                for (int i = 0; i < NumberOfRecipes; i++)
                {
                    double sum = 0.0;
                    //writer.WriteLine("Meal {0}", i);
                    outputs = fileHelper.GetAllUsersRatesForOneDish(i);
                    MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);
                    double errorRegression = regression.Regress(inputs.Take(NumberOfUsersToLearn).ToArray(), outputs.Take(NumberOfUsersToLearn).ToArray());
                    for (int j = NumberOfUsersToLearn; j < NumberOfUsers; j++)
                    {
                        var actual = regression.Compute(inputs[j]);
                        var error = Math.Abs(outputs[j][0] - actual[0]);
                        //sum += error;
                        globalRecipeErrorSum += error;
                        //writer.WriteLine("Actual {0}, {3}, Expected {1}, Error {2}, {4}", Math.Round(actual[0]), Math.Round(outputs[j][0]), Math.Round(error), actual[0], error);
                    }
                    //double average = sum / 7;
                    //writer.WriteLine("Average error: {0}", average);
                    double[] coef = new double[6];
                    for (int l = 0; l < regression.Coefficients.Length; l++)
                    {
                        //writer.WriteLine("x_{0} = {1} ; ", k, regression.Coefficients[k, 0]);
                        coef[l] = regression.Coefficients[l, 0];
                    }
                    //writer.WriteLine();
                    coefficients.Add(coef);
                }


            }


            //using (StreamWriter writer = File.AppendText(PathToLogFile)) 
            //{
            //    for (int i = 0; i < 25; i++)
            //    {
            //        double sum = 0.0;
            //        writer.WriteLine("Meal {0}", i);
            //        var values = fileHelper.ReadFromFile(PathToFile);

            //        double[][] inputs = values.Item1.Take(20).ToArray();

            //        double[][] outputs = values.Item2.Take(20).ToArray();

            //        MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);

            //        double errorRegression = regression.Regress(inputs, outputs);
            //        for (int j = 20; j < 27; j++)
            //        {
            //            var actual = regression.Compute(values.Item1[j]);
            //            var error = Math.Abs(values.Item2[j][0] - actual[0]);
            //            sum += error;
            //            global += error;
            //            writer.WriteLine("Actual {0}, {3}, Expected {1}, Error {2}, {4}", Math.Round(actual[0]), Math.Round(values.Item2[j][0]), Math.Round(error), actual[0], error);
            //        }
            //        double average = sum / 7;
            //        writer.WriteLine("Average error: {0}", average);
            //        double[] coef = new double[6];
            //        for (int k = 0; k < regression.Coefficients.Length; k++)
            //        {
            //            writer.WriteLine("x_{0} = {1} ; ", k, regression.Coefficients[k,0]);
            //            coef[k] = regression.Coefficients[k, 0];
            //        }
            //        writer.WriteLine();
            //        coefficients.Add(coef);

            //        PathToFile = PathToFile.Replace(i.ToString(), (i + 1).ToString());
            //    }
            //    double globalError = global/175;
            //    writer.WriteLine("Global {0}", globalError);
            //}
            return coefficients;
        }

    }
}

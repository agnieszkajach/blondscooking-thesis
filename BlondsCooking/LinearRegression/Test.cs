using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Models.Regression.Linear;

namespace LinearRegression
{
    public class Test
    {
        public string PathToFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\LinearRegression\\bin\\Debug\\meal_0.csv";
        public string PathToLogFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\LinearRegression\\bin\\Debug\\log.txt";
        public void TestMethod()
        {
            FileHelper fileHelper = new FileHelper();
            using (StreamWriter writer = File.AppendText(PathToLogFile))
            {
                for (int i = 0; i < 25; i++)
                {
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
                        writer.WriteLine("Actual {0}, Expected {1}, Error {2}", Math.Round(actual[0]), Math.Round(values.Item2[j][0]), Math.Round(error));
                    }
                    for (int k = 0; k < regression.Coefficients.Length; k++)
                    {
                        writer.WriteLine("x_{0} = {1} ; ", k, regression.Coefficients[k,0]);
                    }
                    writer.WriteLine();

                    PathToFile = PathToFile.Replace(i.ToString(), (i + 1).ToString());
                }
            }
            
            
        }
    }
}

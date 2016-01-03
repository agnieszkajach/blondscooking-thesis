using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Models.Regression.Linear;

namespace LinearRegression
{
    public class Test
    {
        public static readonly string PathToFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\LinearRegression\\bin\\Debug\\meal_0.csv";
        public void TestMethod()
        {
            FileHelper fileHelper = new FileHelper();
            var values = fileHelper.ReadFromFile(PathToFile);

            double[][] inputs = values.Item1;

            double[][] outputs = values.Item2;

            MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);

            double error = regression.Regress(inputs, outputs);
            var actual0 = regression.Compute(new double[] { 5.0, 2.0, 1.0, 5.0, 3.0, 1.0 });
            var actual1 = regression.Compute(new double[] { 3.0, 3.0, 3.0, 4.0, 4.0, 3.0 });
            var actual2 = regression.Compute(new double[] { 4.0, 4.0, 1.0, 3.0, 4.0, 3.0 });
            var actual3 = regression.Compute(new double[] { 2.0, 3.0, 1.0, 5.0, 4.0, 2.0 });
            var actual4 = regression.Compute(new double[] { 5.0, 2.0, 2.0, 5.0, 5.0, 0.0 });


            //double[] inputs = { 10, 20, 30, 40, 50 },
            //double[] outputs = { 20, 40, 60, 80, 100 },
            //SimpleLinearRegression simpleLinearRegression = new SimpleLinearRegression(),
            //double sum = simpleLinearRegression.Regress(inputs, outputs),
            //double error = sum/10,


            //double a = simpleLinearRegression.Slope,
            //double b = simpleLinearRegression.Intercept,
        }
    }
}

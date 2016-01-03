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

            double[][] inputs = values.Item1.Take(15).ToArray();

            double[][] outputs = values.Item2.Take(15).ToArray();

            MultivariateLinearRegression regression = new MultivariateLinearRegression(6, 1);

            double error = regression.Regress(inputs, outputs);
            var actual15 = regression.Compute(values.Item1[15]);
            var actual16 = regression.Compute(values.Item1[16]);
            var actual17 = regression.Compute(values.Item1[17]);
            var actual18 = regression.Compute(values.Item1[18]);
            var actual19 = regression.Compute(values.Item1[19]);

            var error15 = Math.Abs(values.Item2[15][0] - actual15[0]);
            var error16 = Math.Abs(values.Item2[16][0] - actual16[0]);
            var error17 = Math.Abs(values.Item2[17][0] - actual17[0]);
            var error18 = Math.Abs(values.Item2[18][0] - actual18[0]);
            var error19 = Math.Abs(values.Item2[19][0] - actual19[0]);
        }
    }
}

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
        public void TestMethod()
        {
            double[] inputs = { 80, 60, 10, 20, 30 };
            double[] outputs = { 20, 40, 30, 50, 60 };
            SimpleLinearRegression simpleLinearRegression = new SimpleLinearRegression();
            simpleLinearRegression.Regress(inputs, outputs);

            double y = simpleLinearRegression.Compute(85);

            double a = simpleLinearRegression.Slope;
            double b = simpleLinearRegression.Intercept;
        }
    }
}

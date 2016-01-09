using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearRegression
{
    public class FileHelper
    {
        public Tuple<double[][], double[][]> ReadFromFile(string path)
        {
            Tuple<double[][], double[][]> temp;
            double[][] xInAllLines = new double[27][];
            double[][] yInAllLines = new double[27][];
            using (StreamReader streamReader = new StreamReader(path))
            {
                string allLines = streamReader.ReadToEnd();
                var eachLine = allLines.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < eachLine.Length; i++)
                {
                    var valuesInLine = eachLine[i].Split(';');                  
                    double[] xInOneLine = new double[valuesInLine.Length - 2];
                    for (int j = 1; j < valuesInLine.Length; j++)
                    {
                        double parseDouble;
                        var parseSuccessful = Double.TryParse(valuesInLine[j], out parseDouble);
                        if (parseSuccessful)
                        {
                            if (j != valuesInLine.Length - 1)
                            {
                                xInOneLine[j - 1] = parseDouble;
                            }
                            else
                            {
                                yInAllLines[i-1] = new double[] { parseDouble };
                            }
                        }
                        else
                        {
                            if (j != valuesInLine.Length -1)
                            {
                                xInOneLine[j - 1] = 0.0;
                            }
                            else
                            {
                                yInAllLines[i - 1] = new double[] { 0.0 };
                            }
                        }
                    }
                    xInAllLines[i-1] = xInOneLine;
                }
            }
            temp = new Tuple<double[][], double[][]>(xInAllLines, yInAllLines);
            return temp;
        } 
    }
}

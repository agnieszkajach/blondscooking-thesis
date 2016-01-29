using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlondsCooking.Helpers
{
    public class FileHelper
    {
        private const int NumberOfTesters = 27;
        private const int NumberOfRecipes = 25;
        private string PathToFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\BlondsCooking\\bin\\meal_0.csv";
        private string PathToLogFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\BlondsCooking\\bin\\log.txt";
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

        public double[][] GetAllUsersPreferences(int dishId)
        {
            double[][] allUsersPreferences = new double[NumberOfTesters][];
            PathToFile = PathToFile.Replace(0.ToString(), dishId.ToString());
            using (StreamReader streamReader = new StreamReader(PathToFile))
            {
                string allLines = streamReader.ReadToEnd();
                var eachLine = allLines.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < eachLine.Length; i++)
                {
                    var valuesInLine = eachLine[i].Split(';');
                    double[] preferencesOfOneUser = new double[valuesInLine.Length - 2];
                    for (int j = 1; j < valuesInLine.Length -1; j++)
                    {
                        double parseDouble;
                        var parseSuccessful = Double.TryParse(valuesInLine[j], out parseDouble);
                        if (parseSuccessful)
                        {
                            preferencesOfOneUser[j - 1] = parseDouble;
                        }
                        else
                        {
                            preferencesOfOneUser[j - 1] = 0.0;
                        }
                    }
                    allUsersPreferences[i - 1] = preferencesOfOneUser;
                }
            }
            return allUsersPreferences;
        }

        public double[][] GetUserRatesOfAllDishes(int userId)
        {
            double[][] oneUserRatesOfAllDishes = new double[NumberOfRecipes][];
            using (StreamReader streamReader = new StreamReader(PathToFile))
            {
                for (int i = 0; i < NumberOfRecipes; i++)
                {
                    PathToFile = PathToFile.Replace(i.ToString(), (i + 1).ToString());
                    string allLines = streamReader.ReadToEnd();
                    var eachLine = allLines.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    var valuesInLine = eachLine[userId].Split(';');
                    double parseDouble;
                    var parseSuccessful = Double.TryParse(valuesInLine[7], out parseDouble);
                    if (parseSuccessful)
                    {
                        oneUserRatesOfAllDishes[i] = new double[] {parseDouble};
                    }
                    else
                    {
                        oneUserRatesOfAllDishes[i] = new double[] { 0.0 };
                    }
                } 
            }
            return oneUserRatesOfAllDishes;
        }
    }
}

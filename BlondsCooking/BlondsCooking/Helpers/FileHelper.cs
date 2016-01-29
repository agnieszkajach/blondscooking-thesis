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
                                yInAllLines[i - 1] = new double[] { parseDouble };
                            }
                        }
                        else
                        {
                            if (j != valuesInLine.Length - 1)
                            {
                                xInOneLine[j - 1] = 0.0;
                            }
                            else
                            {
                                yInAllLines[i - 1] = new double[] { 0.0 };
                            }
                        }
                    }
                    xInAllLines[i - 1] = xInOneLine;
                }
            }
            temp = new Tuple<double[][], double[][]>(xInAllLines, yInAllLines);
            return temp;
        }

        public double[][] GetAllUsersPreferences()
        {
            string PathToFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\BlondsCooking\\bin\\meal_0.csv";
            double[][] allUsersPreferences = new double[NumberOfTesters][];
            using (StreamReader streamReader = new StreamReader(PathToFile))
            {
                string allLines = streamReader.ReadToEnd();
                var eachLine = allLines.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < eachLine.Length; i++)
                {
                    var valuesInLine = eachLine[i].Split(';');
                    double[] preferencesOfOneUser = new double[valuesInLine.Length - 2];
                    for (int j = 1; j < valuesInLine.Length - 1; j++)
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
            string PathToFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\BlondsCooking\\bin\\meal_0.csv";
            double[][] oneUserRatesOfAllDishes = new double[NumberOfRecipes][];

            for (int i = 0; i < NumberOfRecipes; i++)
            {
                using (StreamReader streamReader = new StreamReader(PathToFile))
                {
                    string allLines = streamReader.ReadToEnd();
                    var eachLine = allLines.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    var properLine = eachLine[userId + 1];
                    var valuesInLine = properLine.Split(';');
                    double parseDouble;
                    var parseSuccessful = Double.TryParse(valuesInLine[7], out parseDouble);
                    if (parseSuccessful)
                    {
                        oneUserRatesOfAllDishes[i] = new double[] { parseDouble };
                    }
                    else
                    {
                        oneUserRatesOfAllDishes[i] = new double[] { 0.0 };
                    }
                    PathToFile = PathToFile.Replace(i.ToString(), (i + 1).ToString());
                }
            }
            return oneUserRatesOfAllDishes;
        }

        public double[][] GetAllUsersRatesForOneDish(int dishId)
        {
            string PathToFile = "C:\\GitHub\\blondscooking-thesis\\BlondsCooking\\BlondsCooking\\bin\\meal_" + dishId + ".csv";
            double[][] allUsersRatesForOneDish = new double[NumberOfTesters][];
            using (StreamReader streamReader = new StreamReader(PathToFile))
            {
                string allLines = streamReader.ReadToEnd();
                var eachLine = allLines.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < eachLine.Length; i++)
                {
                    var valuesInLine = eachLine[i].Split(';');
                    double parseDouble;
                    var parseSuccessful = Double.TryParse(valuesInLine[7], out parseDouble);
                    if (parseSuccessful)
                    {
                        allUsersRatesForOneDish[i - 1] = new double[] { parseDouble };
                    }
                    else
                    {
                        allUsersRatesForOneDish[i - 1] = new double[] { 0.0 };
                    }

                }
            }
            return allUsersRatesForOneDish;
        }
    }
}

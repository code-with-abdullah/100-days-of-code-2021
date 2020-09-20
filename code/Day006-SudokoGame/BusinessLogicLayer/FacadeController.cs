using System;
using System.Collections.Generic;
using DataAccessLayer;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace BusinessLogicLayer
{
    public class FacadeController
    {
        private FacadeController() { }

        private static FacadeController facadeControllerObject = null;

        public static FacadeController GetFacadeController()
        {
            if (facadeControllerObject == null)
                facadeControllerObject = new FacadeController();
            return facadeControllerObject;
        }

        public List<string> getDefaultRandomValueToStartGame(string gameType)
        {
            int maxValue = getMaxValueOfGrid(gameType);

            Random random = new Random();

            int value = 0;

            int totalNoOfWordsInXml = 50;

            List<int> values = new List<int>();

            for (int i = 0; i < maxValue; i++)
            {
                value = random.Next(0, totalNoOfWordsInXml);

                while (values.Contains(value))
                {
                    value = random.Next(0, totalNoOfWordsInXml);
                }
                values.Add(value);
            }

            List<string> valuesUsedInSudoku = DataAccessLayer.FileHandler.getValuesFromFile(values);

            return valuesUsedInSudoku;
        }

        public List<string> getDefaultValuesForTwoByTwoGame()
        {
            List<string> valuesUsedInSudoku = new List<string>(4);

            valuesUsedInSudoku.Add("ا");
            valuesUsedInSudoku.Add("ب");
            valuesUsedInSudoku.Add("پ");
            valuesUsedInSudoku.Add("ت");

            return valuesUsedInSudoku;
        }

        public List<string> getDefaultValuesForThreeByThree()
        {
            List<string> valuesUsedInSudoku = new List<string>(9);

            valuesUsedInSudoku.Add("مدد");
            valuesUsedInSudoku.Add("کریں");
            valuesUsedInSudoku.Add("تبدیل");
            valuesUsedInSudoku.Add("حاصل");
            valuesUsedInSudoku.Add("بند");
            valuesUsedInSudoku.Add("لطف");
            valuesUsedInSudoku.Add("کھیل");
            valuesUsedInSudoku.Add("منتخب");
            valuesUsedInSudoku.Add("آسان");

            return valuesUsedInSudoku;
        }

        public List<int> generateRandomList(int size, string gridType)
        {
            List<int> listToReturn = new List<int>();
            int maxValue = getMaxValueOfGrid(gridType);

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                listToReturn.Add(random.Next(0, maxValue));
            }

            return listToReturn;
        }

        public List<int> generateRandomListTwo(int size, string gridType)
        {
            List<int> listToReturn = new List<int>();
            int maxValue = getMaxValueOfGrid(gridType);

            Random random = new Random(42);

            for (int i = 0; i < size; i++)
            {
                listToReturn.Add(random.Next(0, maxValue));
            }

            return listToReturn;
        }

        public void generateRandomValuesForStartingGame(string gridType, ref List<int> rows, ref List<int> columns)
        {
            int maxValue = getMaxValueOfGrid(gridType);

            Random random = new Random();
            for (int index = 0; index < rows.Count; index++)
            {
                rows.Add(random.Next(0, maxValue));
                columns.Add(random.Next(0, maxValue));
            }
        }

        public int generateARandomValue(string gridType)
        {
            int maxValue = getMaxValueOfGrid("Two");
            Random random = new Random();
            return random.Next(0, maxValue);
        }

        public string convertNumberToUrdu(int number)
        {
            string numberToConvertInString = number.ToString();
            string convertedValue = "";

            foreach (char character in numberToConvertInString)
            {
                convertedValue += getValueOfNumberInUrdu(character);
            }
            return convertedValue;
        }

        private string getValueOfNumberInUrdu(char number)
        {
            switch (number)
            {
                case '0':
                    return "۰";
                case '1':
                    return "۱";
                case '2':
                    return "۲";
                case '3':
                    return "۳";
                case '4':
                    return "۴";
                case '5':
                    return "۵";
                case '6':
                    return "۶";
                case '7':
                    return "۷";
                case '8':
                    return "۸";
                case '9':
                    return "۹";
            }
            throw new Exception("Error in convertion number to urdu");
        }

        public bool foundValueInRow(byte[,] grid, int rowNumber, int currentColumnNo, byte value, string typeOfGrid)
        {
            int maxValue = getMaxValueOfGrid(typeOfGrid);

            for (int column = 0; column < maxValue; column++)
            {
                if (column == currentColumnNo)
                    continue;
                if (grid[rowNumber, column] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public bool isValueRepeatedInRow(byte[,] grid, int rowNumber, int currentColumnNo, byte value, string typeOfGrid)
        {
            int maxValue = getMaxValueOfGrid(typeOfGrid);

            for (int column = 0; column < maxValue; column++)
            {
                if (grid[rowNumber, column] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public bool foundValueInColumn(byte[,] grid, int columnNo, int currentRowNo, byte value, string typeOfGrid)
        {
            int maxValue = getMaxValueOfGrid(typeOfGrid);

            for (int row = 0; row < maxValue; row++)
            {
                if (row == currentRowNo)
                    continue;
                if (grid[row, columnNo] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public bool isValueRepeatedInColumn(byte[,] grid, int columnNo, int currentRowNo, byte value, string typeOfGrid)
        {
            int maxValue = getMaxValueOfGrid(typeOfGrid);

            for (int row = 0; row < maxValue; row++)
            {
                if (grid[row, columnNo] == value)
                {
                    return true;
                }
            }

            return false;
        }

        private int getMaxValueOfGrid(string typeOfGrid)
        {
            switch (typeOfGrid)
            {
                case "Two":
                    return 4;
                case "Three":
                    return 9;
                case "Four":
                    return 16;
            }
            throw new Exception("Invalid string name of grid");
        }

        public bool isGridSolved(byte[,] grid, string typeOfGrid)
        {
            int maxValue = getMaxValueOfGrid(typeOfGrid);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (grid[i, j] == 255)
                    {
                        return false;
                    }
                }
            }


            // First box
            if (grid[0, 0] != grid[0, 1])
            {
                if (grid[0, 0] != grid[1, 0])
                {
                    if (grid[0, 0] != grid[1, 1])
                    {
                        if (grid[0, 1] != grid[1, 0])
                        {
                            if (grid[0, 1] != grid[1, 1])
                            {
                                if (grid[1, 0] != grid[1, 1])
                                {

                                    // Second box
                                    if (grid[0, 2] != grid[0, 3])
                                    {
                                        if (grid[0, 2] != grid[1, 2])
                                        {
                                            if (grid[0, 2] != grid[1, 3])
                                            {
                                                if (grid[0, 3] != grid[1, 2])
                                                {
                                                    if (grid[0, 3] != grid[1, 3])
                                                    {
                                                        if (grid[1, 2] != grid[1, 3])
                                                        {

                                                            // Third box

                                                            if (grid[2, 0] != grid[2, 1])
                                                            {
                                                                if (grid[2, 0] != grid[3, 0])
                                                                {
                                                                    if (grid[2, 0] != grid[3, 1])
                                                                    {
                                                                        if (grid[2, 1] != grid[3, 0])
                                                                        {
                                                                            if (grid[2, 1] != grid[3, 1])
                                                                            {
                                                                                if (grid[3, 0] != grid[3, 1])
                                                                                {

                                                                                    // Fourth box

                                                                                    if (grid[2, 2] != grid[2, 3])
                                                                                    {
                                                                                        if (grid[2, 2] != grid[3, 2])
                                                                                        {
                                                                                            if (grid[2, 2] != grid[3, 3])
                                                                                            {
                                                                                                if (grid[2, 3] != grid[3, 2])
                                                                                                {
                                                                                                    if (grid[2, 3] != grid[3, 3])
                                                                                                    {
                                                                                                        if (grid[3, 2] != grid[3, 3])
                                                                                                        {
                                                                                                            return true;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool isThreeByThreeGridSolved(byte[,] grid)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 255)
                    {
                        return false;
                    }
                }
            }

            #region

            //bool isFirstPanelSolved()
            //{
            //    if (grid[0, 0] != grid[0, 1])
            //    {
            //        if (grid[0, 0] != grid[0, 2])
            //        {
            //            if (grid[0, 0] != grid[1, 0])
            //            {
            //                if (grid[0, 0] != grid[1, 1])
            //                {
            //                    if (grid[0, 0] != grid[1, 2])
            //                    {
            //                        if (grid[0, 0] != grid[2, 0])
            //                        {
            //                            if (grid[0, 0] != grid[2, 1])
            //                            {
            //                                if (grid[0, 0] != grid[2, 2])
            //                                {
            //                                    if (grid[0, 1] != grid[0, 2])
            //                                    {
            //                                        if (grid[0, 1] != grid[1, 0])
            //                                        {
            //                                            if (grid[0, 1] != grid[1, 1])
            //                                            {
            //                                                if (grid[0, 1] != grid[1, 2])
            //                                                {
            //                                                    if (grid[0, 1] != grid[2, 0])
            //                                                    {
            //                                                        if (grid[0, 1] != grid[2, 1])
            //                                                        {
            //                                                            if (grid[0, 1] != grid[2, 2])
            //                                                            {
            //                                                                if (grid[0, 2] != grid[1, 0])
            //                                                                {
            //                                                                    if (grid[0, 2] != grid[1, 1])
            //                                                                    {
            //                                                                        if (grid[0, 2] != grid[1, 2])
            //                                                                        {
            //                                                                            if (grid[0, 2] != grid[2, 0])
            //                                                                            {
            //                                                                                if (grid[0, 2] != grid[2, 1])
            //                                                                                {
            //                                                                                    if (grid[0, 2] != grid[2, 2])
            //                                                                                    {
            //                                                                                        if (grid[1, 0] != grid[1, 1])
            //                                                                                        {
            //                                                                                            if (grid[1, 0] != grid[1, 2])
            //                                                                                            {
            //                                                                                                if (grid[1, 0] != grid[2, 0])
            //                                                                                                {
            //                                                                                                    if (grid[1, 0] != grid[2, 1])
            //                                                                                                    {
            //                                                                                                        if (grid[1, 0] != grid[2, 2])
            //                                                                                                        {
            //                                                                                                            return true;
            //                                                                                                        }
            //                                                                                                    }
            //                                                                                                }
            //                                                                                            }
            //                                                                                        }
            //                                                                                    }
            //                                                                                }
            //                                                                            }
            //                                                                        }
            //                                                                    }
            //                                                                }
            //                                                            }
            //                                                        }
            //                                                    }
            //                                                }
            //                                            }
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    return false;
            //}

            #endregion

            return true;
        }

        public bool isValueRepeatedInRowUpdated(byte[,] grid, int row, string typeOfGrid)
        {
            int maxValue = getMaxValueOfGrid(typeOfGrid);

            int i = 0;

            for (int column = 0; column < maxValue; column++)
            {
                i = column + 1;

                while (i < maxValue)
                {
                    if (!(grid[row, column] == 255 || grid[row, i] == 255))
                    {
                        if (grid[row, column] == grid[row, i])
                        {
                            return true;
                        }
                    }
                    i++;
                }
            }

            return false;
        }

        public bool isValueRepeatedInColumnUpdated(byte[,] grid, int column, string typeOfGrid)
        {
            int maxValue = getMaxValueOfGrid(typeOfGrid);

            for (int row = 0; row < maxValue; row++)
            {
                for (int k = row + 1; k < maxValue; k++)
                {
                    if (!(grid[row, column] == 255 || grid[k, column] == 255))
                    {
                        if (grid[row, column] == grid[k, column])
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool isCnicFormated(string cnic)
        {
            Regex cnicFormat = new Regex(@"^[\d]{5}-[\d]{7}-[\d]{1}$");
            return cnicFormat.IsMatch(cnic) ? true : false;
        }

        public void insertToDatabase(string cnic, int moves, int minutes, int seconds, int gameType)
        {
            ConnectToDatabase connectToDatabase = new ConnectToDatabase();
            connectToDatabase.executeNonQuery("Insert into Games(CNIC, Moves, MinutesTaken, SecondsTaken, GameType) Values('" + cnic + "', " + moves + ", " + minutes + ", " + seconds + ", " + gameType + ")");
        }

        public SqlDataReader readTopTenGames(char gameType = ' ')
        {
            string query = @"SELECT TOP 10 * FROM Games ORDER By MinutesTaken";

            ConnectToDatabase connectToDatabase = new ConnectToDatabase();
            return connectToDatabase.executeReader(query);
        }
    }
}

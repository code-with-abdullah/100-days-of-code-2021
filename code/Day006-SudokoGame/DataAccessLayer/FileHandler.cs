using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccessLayer
{
    public class FileHandler
    {
        public static List<string> getValuesFromFile(List<int> indexesToGet)
        {
            List<string> randomValues = new List<string>();

            string[] linesinTxtFile = File.ReadAllLines("Corpus.txt");

            for (int i = 0; i < indexesToGet.Count; i++)
            {
                randomValues.Add(linesinTxtFile[indexesToGet[i]]);
            }

            return randomValues;
        }
    }
}

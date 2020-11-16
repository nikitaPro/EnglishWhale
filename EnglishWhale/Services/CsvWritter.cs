using EnglishWhale.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Services
{
    public class CsvWritter
    {
        public static void writeCsv(LanguageDictionary lDict, string path)
        {
            StringBuilder builder = new StringBuilder();
            string from = lDict.From;
            string to = lDict.To;
            List<WordsPair> list = new List<WordsPair>(lDict.LearnedWords.Count + lDict.WordsToStudy.Count);
            list.AddRange(lDict.LearnedWords);
            list.AddRange(lDict.WordsToStudy);

            foreach (WordsPair wPair in list)
            {
                builder.Append(from);
                builder.Append(",");
                builder.Append(to);
                builder.Append(",");
                builder.Append(wPair.ToString());
                builder.AppendLine();
            }

            File.WriteAllText(path, builder.ToString(), Encoding.Default);
        }
    }
}

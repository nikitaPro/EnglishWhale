using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishWhale.Models;
using System.IO;

namespace EnglishWhale.Services
{
    public class CsvReader
    {
        public List<LanguageDictionary> Vocabularies { get; }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private string path;
        public CsvReader(string path)
        {
            Vocabularies = new List<LanguageDictionary>();
            this.path = path;
            readCsv();
        }

        private void readCsv()
        {
            checkEmptyFields();
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                LanguageDictionary directTranslation;
                LanguageDictionary reversTranslation;
                // set up parser
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.TrimWhiteSpace = true;
                // read first row
                string[] fields = csvParser.ReadFields();
                
                EnglishDetector enDetector = new EnglishDetector(); // Detector for determining where English is.
                LanguageDictionary.EnglishIs englishIs ;
                string from = fields[0];
                string to = fields[1];
                try
                {
                    englishIs = enDetector.isTheDirectionEnglish(to)
                        ? LanguageDictionary.EnglishIs.TO
                        : (enDetector.isTheDirectionEnglish(from) 
                        ? LanguageDictionary.EnglishIs.FROM 
                        : LanguageDictionary.EnglishIs.NEITHER);
                }
                catch (System.Exception)
                {
                    englishIs = LanguageDictionary.EnglishIs.NEITHER;
                    Logger.Error("Fail when detector trying to determine english language.");
                    throw new IOException("No internet connection.");
                }
                if (englishIs.Equals(LanguageDictionary.EnglishIs.NEITHER))
                {
                    throw new IOException("No english at first row.");
                }

                // initiate dictionary with first row
                directTranslation = new LanguageDictionary(fields[0], fields[1], englishIs);
                directTranslation.Dict.Add(fields[2], fields[3]);
                reversTranslation = new LanguageDictionary(fields[1], fields[0], 
                    englishIs.Equals(LanguageDictionary.EnglishIs.TO) ? LanguageDictionary.EnglishIs.FROM : LanguageDictionary.EnglishIs.TO);
                reversTranslation.Dict.Add(fields[3], fields[2]);
                // let's process other rows
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    fields = csvParser.ReadFields();
                    string firstWord = fields[2];
                    string secondWord = fields[3];

                    if (fields[0].Equals(directTranslation.From))
                    {
                        // if key exist then concatenates second meaning to translation
                        if (directTranslation.ContainsKey(firstWord))
                            directTranslation[firstWord] = $"{directTranslation[firstWord]}; {secondWord}";
                        else
                            directTranslation.Add(firstWord, secondWord);

                        if (reversTranslation.ContainsKey(secondWord))
                            reversTranslation[secondWord] = $"{reversTranslation[secondWord]}; {firstWord}";
                        else
                            reversTranslation.Add(secondWord, firstWord);
                    } 
                    else if (fields[0].Equals(reversTranslation.From))
                    {
                        if (reversTranslation.ContainsKey(firstWord))
                            reversTranslation[firstWord] = $"{reversTranslation[firstWord]}; {secondWord}";
                        else
                            reversTranslation.Add(firstWord, secondWord);

                        if (directTranslation.ContainsKey(secondWord))
                            directTranslation[secondWord] = $"{directTranslation[secondWord]}; {firstWord}";
                        else
                            directTranslation.Add(secondWord, firstWord);
                    }
                    else
                    {
                        Logger.Info("Too many languages. Skipping this row: {0}, {1}, {2}, {3}", fields[0], fields[1], fields[2], fields[3]);
                    }
                   
                }
                Vocabularies.Add(directTranslation);
                Vocabularies.Add(reversTranslation);
                // TODO: Delete below
                Console.WriteLine($"{directTranslation.From} -> {directTranslation.To} {directTranslation.Dict.Count}");
                Console.WriteLine($"{reversTranslation.From} -> {reversTranslation.To} {reversTranslation.Dict.Count}");
            }
        }

        private void checkEmptyFields()
        {
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                // set up parser
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;
                csvParser.TrimWhiteSpace = true;
                // read first row
                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    foreach (string cell in fields)
                    {
                        if (String.IsNullOrWhiteSpace(cell))
                        {
                            throw new IOException("File contains empty cells.");
                        }
                    }
                }
            }
        }
    }
}

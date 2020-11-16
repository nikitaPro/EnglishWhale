using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;
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
            using (TextFieldParser csvParser = new TextFieldParser(path, Encoding.Default))
            {
                Dictionary<string, WordsPair> directTranslation = new Dictionary<string, WordsPair>();
                Dictionary <string, WordsPair> reversTranslation = new Dictionary<string, WordsPair>(); ;
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
                string firstWord = fields[2];
                string secondWord = fields[3];
                bool studied = false;
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
                if (fields.Length == 5)
                {
                    studied = fields[4].Equals("1");
                }
                // initiate dictionary with first row
                directTranslation.Add(fields[2], new WordsPair(firstWord, secondWord, studied));
                reversTranslation.Add(fields[3], new WordsPair(secondWord, firstWord, studied)); 
                // let's process other rows
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    fields = csvParser.ReadFields();
                    firstWord = fields[2];
                    secondWord = fields[3];
                    studied = false;
                    if (fields.Length == 5)
                    {
                        studied = fields[4].Equals("1");
                    }

                    if (fields[0].Equals(from))
                    {
                        // if key exist then concatenates second meaning to translation
                        if (directTranslation.ContainsKey(firstWord))
                            directTranslation[firstWord] = new WordsPair(firstWord, $"{directTranslation[firstWord].Translation}; {secondWord}", studied);
                        else
                            directTranslation.Add(firstWord, new WordsPair(firstWord, secondWord, studied));

                        if (reversTranslation.ContainsKey(secondWord))
                            reversTranslation[secondWord] = new WordsPair(secondWord, $"{reversTranslation[secondWord].Translation}; {firstWord}", studied);
                        else
                            reversTranslation.Add(secondWord, new WordsPair(secondWord, firstWord, studied));
                    } 
                    else if (fields[0].Equals(to))
                    {
                        if (reversTranslation.ContainsKey(firstWord))
                            reversTranslation[firstWord] = new WordsPair(firstWord, $"{reversTranslation[firstWord].Translation}; {secondWord}", studied);
                        else
                            reversTranslation.Add(firstWord, new WordsPair(firstWord, secondWord, studied));

                        if (directTranslation.ContainsKey(secondWord))
                            directTranslation[secondWord] = new WordsPair(secondWord, $"{directTranslation[secondWord].Translation}; {firstWord}", studied);
                        else
                            directTranslation.Add(secondWord, new WordsPair(secondWord, firstWord, studied));
                    }
                    else
                    {
                        Logger.Info("Too many languages. Skipping this row: {0}, {1}, {2}, {3}", fields[0], fields[1], fields[2], fields[3]);
                    }
                   
                }

                LanguageDictionary directTranslationLanguageDictionary = new LanguageDictionary(from, to, englishIs);
                LanguageDictionary reversTranslationLanguageDictionary = new LanguageDictionary(to, from, 
                    englishIs.Equals(LanguageDictionary.EnglishIs.TO) ? LanguageDictionary.EnglishIs.FROM : LanguageDictionary.EnglishIs.TO);
                foreach (WordsPair wPair in directTranslation.Values)
                {
                    directTranslationLanguageDictionary.Add(wPair);
                }
                foreach (WordsPair wPair in reversTranslation.Values)
                {
                    reversTranslationLanguageDictionary.Add(wPair);
                }
                Vocabularies.Add(directTranslationLanguageDictionary);
                Vocabularies.Add(reversTranslationLanguageDictionary);

                // TODO: Delete below
                Console.WriteLine($"{directTranslationLanguageDictionary} {directTranslation.Count}");
                Console.WriteLine($"{reversTranslationLanguageDictionary} {reversTranslation.Count}");
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
                if (csvParser.EndOfData)
                {
                    throw new IOException("File is empty.");
                }
                // read first row
                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    if (fields.Length < 4)
                    {
                        throw new IOException("File has missing columns.");
                    }
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

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishWhale.Models;

namespace EnglishWhale.Services
{
    public class CsvReader
    {
        public List<LanguageDictionary> Vocabularies { get; }
        private string path;
        public CsvReader(string path)
        {
            Vocabularies = new List<LanguageDictionary>();
            this.path = path;
            readCsv();
        }

        private void readCsv()
        {
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
                // initiate dictionary with first row
                directTranslation = new LanguageDictionary(fields[0], fields[1]);
                directTranslation.Dict.Add(fields[2], fields[3]);
                reversTranslation = new LanguageDictionary(fields[1], fields[0]);
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
                        Console.WriteLine("Too many languages in the file. Skipping this row.");
                    }
                   
                }
                Vocabularies.Add(directTranslation);
                Vocabularies.Add(reversTranslation);
                // TODO: Delete below
                Console.WriteLine($"{directTranslation.From} -> {directTranslation.To} {directTranslation.Dict.Count}");
                foreach (KeyValuePair<string, string> pair in directTranslation.Dict) 
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value}");
                }
                Console.WriteLine($"{reversTranslation.From} -> {reversTranslation.To} {reversTranslation.Dict.Count}");
                foreach (KeyValuePair<string, string> pair in reversTranslation.Dict)
                {
                    Console.WriteLine($"{pair.Key} -> {pair.Value}");
                }
            }
        }
    }
}

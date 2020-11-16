using EnglishWhale.Services;
using System.Collections.Generic;

namespace EnglishWhale.Models
{
    public class LanguageDictionary
    {
        public enum EnglishIs
        {
            FROM,
            TO,
            NEITHER
        }
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public string From { get; }
        public string To { get; }
        public List<WordsPair> LearnedWords { get; protected set; }
        public List<WordsPair> WordsToStudy { get; protected set; }
        private EnglishIs english;
        public bool IsEnglishTo { get { return english.Equals(EnglishIs.TO); } }
        public bool IsEnglishFrom { get { return english.Equals(EnglishIs.FROM); } }

        public LanguageDictionary(string from, string to, EnglishIs fromOrTo)
        {
            From = from;
            To = to;
            english = fromOrTo;
            WordsToStudy = new List<WordsPair>();
            LearnedWords = new List<WordsPair>();
        }

        /*public WordsPair this[string s]
        {
            get { return Dict[s];  }
            set { Dict[s] = value;  }
        }*/

        public void Add (WordsPair pair)
        {
            pair.WordStudied += moveWordPair;
            if (pair.Studied)
            {
                LearnedWords.Add(pair);
            } 
            else
            {
                WordsToStudy.Add(pair);
            }
        }

        public void moveWordPair(WordsPair wPair)
        {
            if (wPair.Studied)
            {
                if (WordsToStudy.Remove(wPair))
                {
                    LearnedWords.Add(wPair);
                }
            }
            if (WordsToStudy.Count == 0)
            {
                WordsToStudy = LearnedWords;
                LearnedWords = new List<WordsPair>();
                foreach (WordsPair pair in WordsToStudy)
                {
                    pair.Reset();
                }
            }
        }

        public override string ToString()
        {
            return $"{From} -> {To}";
        }

    }
}

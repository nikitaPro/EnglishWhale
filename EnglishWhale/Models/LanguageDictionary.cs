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
        public Dictionary<string, string> Dict { get; }
        private EnglishIs english;
        public bool IsEnglishTo { get { return english.Equals(EnglishIs.TO); } }
        public bool IsEnglishFrom { get { return english.Equals(EnglishIs.FROM); } }

        public LanguageDictionary(string from, string to, EnglishIs fromOrTo)
        {
            From = from;
            To = to;
            english = fromOrTo;
            Dict = new Dictionary<string, string>();
        }

        public string this[string s]
        {
            get { return Dict[s];  }
            set { Dict[s] = value;  }
        }

        public void Add (string s1, string s2)
        {
            Dict.Add(s1, s2);
        }

        public bool ContainsKey(string key)
        {
            return Dict.ContainsKey(key);
        }

        public override string ToString()
        {
            return $"{From} -> {To}";
        }

    }
}

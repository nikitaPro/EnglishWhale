using EnglishWhale.Services;
using System.Collections.Generic;

namespace EnglishWhale.Models
{
    public class LanguageDictionary
    {
        public string From { get; }
        public string To { get; }
        public Dictionary<string, string> Dict { get; }
        private string english;
        public bool IsEnglishTo { get { return "to".Equals(english); } }
        public bool IsEnglishFrom { get { return "from".Equals(english); } }

        public LanguageDictionary(string from, string to, EnglishDetector detector)
        {
            From = from;
            To = to;
            Dict = new Dictionary<string, string>();
            whereIsEnglish(detector);
        }

        private void whereIsEnglish(EnglishDetector detector)
        {
            english = detector.isTheDirectionEnglish(To) 
                ? "to" 
                : (detector.isTheDirectionEnglish(From) ? "from" : null);
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

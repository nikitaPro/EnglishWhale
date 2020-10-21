using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Models
{
    class LanguageDictionary
    {
        public string From { get; }
        public string To { get; }
        public Dictionary<string, string> Dict { get; }

        public LanguageDictionary(string from, string to)
        {
            From = from;
            To = to;
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
    }
}

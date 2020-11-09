using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Models
{
    public class WordsPair
    {
        public string Original { get; }
        public string Translation { get; }
        public bool Learned { get; set; }

        public WordsPair(string orig, string trans)
        {
            Original = orig;
            Translation = trans;
            Learned = false;
        }

        public override bool Equals(object obj)
        {
            return obj is WordsPair pair &&
                   Original == pair.Original &&
                   Translation == pair.Translation;
        }

        public override int GetHashCode()
        {
            int hashCode = 892381230;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Original);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Translation);
            return hashCode;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Models
{
    public class WordsPair
    {
        public delegate void FireWordStudied(WordsPair sender);
        public event FireWordStudied WordStudied;
        public string Original { get; }
        public string Translation { get; }
        protected bool studied;
        public bool Studied 
        { 
            get { return studied; } 
            set 
            { 
                studied = value;
                if (studied)
                {
                    WordStudied(this);
                }
            } 
        }
        public WordsPair(string orig, string trans, bool learned)
        {
            Original = orig;
            Translation = trans;
            studied = learned;
        }
        public WordsPair(string orig, string trans) : this(orig, trans, false) { }

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

        public override string ToString()
        {
            return $"\"{Original}\",\"{Translation}\",{(studied ? 1 : 0)}";
        }

        public void Reset()
        {
            studied = false;
        }
    }
}

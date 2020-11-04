using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Models
{
    public class LearningSet
    {
        public List<KeyValuePair<string, string>> pairs;

        public LearningSet(List<KeyValuePair<string, string>> pairsList)
        {
            this.pairs = pairsList;
        }


    }
}

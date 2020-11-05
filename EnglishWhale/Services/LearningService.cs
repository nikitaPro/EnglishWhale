using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Services
{
    public class LearningService
    {
        private List<KeyValuePair<string, string>> words;
        private List<KeyValuePair<string, string>> tempWords;
        private Random rnd;
        private bool round;
        public bool RoundFinish 
        {
            get
            {
                if (round)
                {
                    round = false;
                    return true;
                }
                return round;
            }
        } 

        public LearningService(List<KeyValuePair<string, string>> someWords)
        {
            this.words = someWords;
            CreateNewTempWordsBuffer();
            rnd = new Random((int)DateTime.Now.ToBinary());
            round = false;
        }

        public KeyValuePair<string, string> GetNextWord()
        {
            KeyValuePair<string, string> pair = MovePairFromOneBuffeToOther(words, tempWords);
            if (words.Count == 0)
            {
                Reload();
                round = true;
            }
            return pair;
        }

        private void Reload()
        {
            words = tempWords;
            CreateNewTempWordsBuffer();
        }

        private KeyValuePair<string, string> MovePairFromOneBuffeToOther(List<KeyValuePair<string, string>> bufSrc, List<KeyValuePair<string, string>> bufDest)
        {
            KeyValuePair<string, string> pair = bufSrc.ElementAt(rnd.Next(bufSrc.Count));
            bufSrc.Remove(pair);
            bufDest.Add(pair);
            return pair;
        }

        private void CreateNewTempWordsBuffer()
        {
            tempWords = new List<KeyValuePair<string, string>>();
        }

    }
}

using EnglishWhale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Services
{
    public class LearningService
    {
        private List<WordsPair> words;
        private List<WordsPair> tempWords;
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

        public LearningService(List<WordsPair> someWords)
        {
            this.words = someWords;
            CreateNewTempWordsBuffer();
            rnd = new Random((int)DateTime.Now.ToBinary());
            round = false;
        }

        public WordsPair GetNextWord()
        {
            WordsPair pair = MovePairFromOneBuffeToOther(words, tempWords);
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

        private WordsPair MovePairFromOneBuffeToOther(List<WordsPair> bufSrc, List<WordsPair> bufDest)
        {
            WordsPair pair = bufSrc.ElementAt(rnd.Next(bufSrc.Count));
            bufSrc.Remove(pair);
            bufDest.Add(pair);
            return pair;
        }

        private void CreateNewTempWordsBuffer()
        {
            tempWords = new List<WordsPair>();
        }

    }
}

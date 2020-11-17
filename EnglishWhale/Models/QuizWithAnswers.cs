using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWhale.Models
{
    public class QuizWithAnswers
    {
        public string Question { get; }
        public string RightAnswer { get; }
        public string Answer2 { get; }
        public string Answer3 { get; }
        public string Answer4 { get; }

        public QuizWithAnswers(string question, string rightAnswer, string ans2, string ans3, string ans4)
        {
            Question = question;
            RightAnswer = rightAnswer;
            Answer2 = ans2;
            Answer3 = ans3;
            Answer4 = ans4;
        }
    }
}

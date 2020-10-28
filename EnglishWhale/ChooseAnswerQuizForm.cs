using EnglishWhale.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWhale
{
    public partial class ChooseAnswerQuizForm : Form
    {
        private MainController mContr;
        private Button rightAnswerBtn;
        public bool MuteQuestion { get; set; }
        public bool MuteAnswer { get; set; }
        public ChooseAnswerQuizForm(MainController mContr)
        {
            InitializeComponent();
            this.mContr = mContr;
            MuteQuestion = true;
            MuteAnswer = true;
        }

        public void setQuestion(string question)
        {
            questionTextBox.Text = question;
            questionTextBox.SelectAll();
            questionTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        public void setAnswers(string rightAnswer, string answer2, string answer3, string answer4)
        {
            List<Button> bList = new List<Button>() { button1, button2, button3, button4 };

            Random rnd = new Random();
            int rightAnswerBtnPosition = rnd.Next(0, 3);

            rightAnswerBtn = bList[rightAnswerBtnPosition];
            rightAnswerBtn.Text = rightAnswer;
            rightAnswerBtn.Click += this.rightAnswer;
            bList.RemoveAt(rightAnswerBtnPosition);


            Queue<Button> queueButtons = new Queue<Button>(bList);
            Button button = queueButtons.Dequeue();
            button.Text = answer2;
            button.Click += wrongAnswer;

            button = queueButtons.Dequeue();
            button.Text = answer3;
            button.Click += wrongAnswer;

            button = queueButtons.Dequeue();
            button.Text = answer4;
            button.Click += wrongAnswer;

        }

        private void wrongAnswer(object sender, EventArgs e)
        {
            Button wrongAnswerBtn = sender as Button;
            wrongAnswerBtn.BackColor = Color.Red;
            rightAnswerBtn.BackColor = Color.Green;
            Timer tm = new Timer();
            tm.Interval = 1000;
            tm.Tick += delegate {
                this.Close();
                this.Dispose();
                mContr.WrongChooseAnswer();
                tm.Stop();
                tm.Dispose();
            };
            tm.Start();
        }

        private void rightAnswer(object sender, EventArgs e)
        {
            Button rightAnswerBtn = sender as Button;
            rightAnswerBtn.BackColor = Color.Green;
            Timer tm = new Timer();
            tm.Interval = 500;
            tm.Tick += delegate {
                this.Close();
                this.Dispose();
                mContr.RightChooseAnswer();
                tm.Stop();
                tm.Dispose();
            };
            tm.Start();
        }

        private void volumePic_MouseEnter(object sender, EventArgs e)
        {
            if (MuteQuestion) return;
            string phrase = questionTextBox.Text;
            mContr.SpeakThis(phrase);
        }
    }
}

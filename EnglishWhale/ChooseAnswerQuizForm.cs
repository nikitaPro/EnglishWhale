using EnglishWhale.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWhale
{
    public partial class ChooseAnswerQuizForm : Form
    {
        private MainController mContr;
        public ChooseAnswerQuizForm(MainController mContr)
        {
            InitializeComponent();
            this.mContr = mContr;
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

            bList[rightAnswerBtnPosition].Text = rightAnswer;
            bList[rightAnswerBtnPosition].Click += this.rightAnswer;
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
            this.BackColor = Color.Red;
            Timer tm = new Timer();
            tm.Interval = 500;
            tm.Tick += delegate {
                this.Close();
                this.Dispose();
                mContr.wrongChooseAnswer();
                tm.Stop();
                tm.Dispose();
            };
            tm.Start();
        }

        private void rightAnswer(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
            Timer tm = new Timer();
            tm.Interval = 500;
            tm.Tick += delegate {
                this.Close();
                this.Dispose();
                mContr.rightChooseAnswer();
                tm.Stop();
                tm.Dispose();
            };
            tm.Start();
        }
    }
}

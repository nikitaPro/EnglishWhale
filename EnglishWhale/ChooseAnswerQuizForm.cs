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
        private const int SECONDS = 10;
        private int timeCounter;

        private MainController mContr;
        private Button rightAnswerBtn;
        private Timer answerTimer;
        public bool MuteQuestion { get; set; }
        public bool MuteAnswer { get; set; }
        public ChooseAnswerQuizForm(MainController mContr, bool timer)
        {
            InitializeComponent();
            this.mContr = mContr;
            MuteQuestion = true;
            MuteAnswer = true;
            setTimer(timer);
            this.FormClosing += ChooseAnswerQuizForm_FormClosing;
        }

        private void ChooseAnswerQuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopAnswerTimer();
        }

        private void setTimer(bool isSet)
        {
            if (isSet)
            {
                timerBar.Maximum = SECONDS;
                timeCounter = 0;
                answerTimer = new Timer();
                answerTimer.Interval = 1000;
                answerTimer.Tick += timerHandler;
                answerTimer.Start();
            }
            else
            {
                timerBar.Visible = false;
                timerLabel.Visible = false;
            }
        }
        private void stopAnswerTimer()
        {
            if (answerTimer != null)
            {
                answerTimer.Stop();
                answerTimer.Dispose();
            }
        }
        private void timerHandler(object sender, EventArgs e)
        {
            if (timeCounter == SECONDS)
            {
                wrongAnswer(this, null);
                return;
            }
            timeCounter++;
            timerBar.Value = timeCounter;
        }

        public void setQuestion(string question)
        {
            if (!MuteQuestion)
            {
                mContr.SpeakThis(question);
            }
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
            rightAnswerBtn.MouseEnter += volumeFromButton_MouseEnter;
            bList.RemoveAt(rightAnswerBtnPosition);


            Queue<Button> queueButtons = new Queue<Button>(bList);
            Button button = queueButtons.Dequeue();
            button.Text = answer2;
            button.Click += wrongAnswer;
            button.MouseEnter += volumeFromButton_MouseEnter;

            button = queueButtons.Dequeue();
            button.Text = answer3;
            button.Click += wrongAnswer;
            button.MouseEnter += volumeFromButton_MouseEnter;

            button = queueButtons.Dequeue();
            button.Text = answer4;
            button.Click += wrongAnswer;
            button.MouseEnter += volumeFromButton_MouseEnter;
        }

        private void wrongAnswer(object sender, EventArgs e)
        {
            stopAnswerTimer();
            makeAllButtonsDisabled();

            Control wrongAnswerBtn = sender as Control;
            wrongAnswerBtn.BackColor = Color.Red;
            rightAnswerBtn.BackColor = Color.Green;
            Timer tm = new Timer();
            tm.Interval = 2000;
            tm.Tick += delegate {
                this.Close();
                this.Dispose();
                mContr.WrongChooseAnswer();
                tm.Stop();
                tm.Dispose();
            };
            tm.Start();
            if (!MuteAnswer)
            {
                mContr.SpeakThis(rightAnswerBtn.Text);
            }
        }

        private void rightAnswer(object sender, EventArgs e)
        {
            stopAnswerTimer();
            makeAllButtonsDisabled();

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
            if (!MuteQuestion)
            {
                mContr.SpeakThis(questionTextBox.Text);
            }
        }

        private void volumePic_MouseEnter(object sender, EventArgs e)
        {
            if (MuteQuestion) return;
            string phrase = questionTextBox.Text;
            mContr.SpeakThis(phrase);
        }

        private void volumeFromButton_MouseEnter(object sender, EventArgs e)
        {
            if (MuteAnswer) return;
            Button btn = sender as Button;
            string phrase = btn.Text;
            mContr.SpeakThis(phrase);
        }

        private void makeAllButtonsDisabled()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        } 
    }
}

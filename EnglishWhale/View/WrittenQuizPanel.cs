using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnglishWhale.Controller;
using EnglishWhale.Models;

namespace EnglishWhale.View
{
    public partial class WrittenQuizPanel : Panel
    {
        public delegate WordsPair GetWordPairMethod(MainController mController);
        private int timerLimit = 1;
        private Timer timer;
        private MainController mContr;
        private int timeCounter;
        private string rightAnswer;
        private Color normalBackColor;
        private Color normalForeColor;
        private GetWordPairMethod GetWordPairVisit;
        public bool MuteQuestion { get; set; }
        public bool MuteAnswer { get; set; }
        public WrittenQuizPanel(MainController mContr, GetWordPairMethod dataSourceVisit)
        {
            this.GetWordPairVisit = dataSourceVisit;
            MuteQuestion = true;
            MuteAnswer = true;
            this.mContr = mContr;
            InitializeComponent();
            GetNextWordsPair();
            StatrTimer();
            this.Disposed += delegate { timer.Stop(); timer.Dispose(); };
        }

        private void NextButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Button btn = sender as Button;
            int rWidth = 30;
            int rHeight = 10;
            Rectangle rect = new Rectangle(5, btn.Height / 2 - rHeight / 2, rWidth, rHeight);
            g.FillRectangle(Brushes.Black, rect);
            Point[] polygonPoint = new Point[]{ new Point(rect.X + rWidth, rect.Y - 7),
                new Point(rect.X + rWidth, rect.Y + rHeight + 7),
                new Point(rWidth + rect.X + 10, btn.Height / 2) };
            g.FillPolygon(Brushes.Black, polygonPoint);
        }

        private void GetNextWordsPair()
        {
            WordsPair pair = GetWordPairVisit(mContr);
            if (pair == null)
            {
                timer.Stop();
                return;
            }
            string question = pair.Original;
            questionTextBox.Text = question;
            questionTextBox.SelectAll();
            questionTextBox.SelectionAlignment = HorizontalAlignment.Center;
            questionTextBox.DeselectAll();
            if (!MuteQuestion)
            {
                mContr.SpeakThis(question);
            }
            rightAnswer = pair.Translation;
        }

        private void StatrTimer()
        {
            timeCounter = 0;
            timerLimit = rightAnswer.Length > 10 ? rightAnswer.Length : 10;

            timerBar.Maximum = timerLimit;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeCounter == timerLimit)
            {
                WrongAnswer(answerTextBox, null);
                return;
            }
            timeCounter++;
            timerBar.Value = timeCounter;
        }
        private void WrongAnswer(object sender, EventArgs e)
        {
            SetEnebledWithRefresh(nextButton, false);
            Control tBox = sender as Control;
            normalBackColor = tBox.BackColor;
            normalForeColor = tBox.ForeColor;
            tBox.BackColor = Color.Red;
            tBox.ForeColor = Color.White;
            Reset();
        }

        private void AnswerTextBoxReset_Tick(object sender, EventArgs e)
        {
            if (this.IsDisposed) return;
            Timer tmr = sender as Timer;
            tmr.Stop();
            tmr.Dispose();
            answerTextBox.BackColor = normalBackColor;
            answerTextBox.ForeColor = normalForeColor;
            answerTextBox.Text = String.Empty;
            answerTextBox.TextChanged += AnswerTextBox_TextChanged;
            answerTextBox.ReadOnly = false;
            GetNextWordsPair();
            StatrTimer();
            SetEnebledWithRefresh(nextButton, true);
        }

        private void AnswerTextBox_TextChanged(object sender, EventArgs e)
        {
            SetEnebledWithRefresh(nextButton, false);
            string answer = answerTextBox.Text;
            bool isRightAns = mContr.isRightAnswer(rightAnswer, answer);
            if (isRightAns)
            {
                Control tBox = sender as Control;
                normalBackColor = tBox.BackColor;
                normalForeColor = tBox.ForeColor;
                tBox.BackColor = Color.Green;
                tBox.ForeColor = Color.White;
                Reset();
            }
            else
            {
                SetEnebledWithRefresh(nextButton, true);
            }
        }

        private void Reset()
        {
            answerTextBox.TextChanged -= AnswerTextBox_TextChanged;
            answerTextBox.ReadOnly = true;
            answerTextBox.Text = rightAnswer;
            timer.Stop();
            timeCounter = 0;
            timerBar.Value = timeCounter;
            if (!MuteAnswer)
            {
                mContr.SpeakThis(rightAnswer);
            }
            Timer tmr = new Timer();
            tmr.Interval = 5000;
            tmr.Tick += AnswerTextBoxReset_Tick;
            tmr.Start();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SetEnebledWithRefresh(btn, false);
            string userAnswer = answerTextBox.Text;
            if (String.IsNullOrEmpty(userAnswer))
            {
                answerTextBox.Text = rightAnswer.Substring(0, 1);
                SetEnebledWithRefresh(btn, true);
                return;
            }
            // If you use this for help you with the last letter then you will lose
            if (userAnswer.StartsWith(rightAnswer.Substring(0, rightAnswer.Length - 1)))
            {
                WrongAnswer(answerTextBox, null);
                return;
            }
            if (mContr.isRightAnswer(rightAnswer, userAnswer))
            {
                SetEnebledWithRefresh(btn, true);
                return;
            }

            char[] rAnsChars = rightAnswer.ToCharArray();
            char[] userAnsChars = userAnswer.ToCharArray();
            char[] helpChars = new char[rAnsChars.Length];

            for (int i = 0; i < rAnsChars.Length; i++)
            {
                helpChars[i] = rAnsChars[i];
                if (userAnsChars.Length - 1 == i)
                {
                    helpChars[i + 1] = rAnsChars[i + 1];
                    break;
                }
                if (userAnsChars[i] != rAnsChars[i])
                {
                    break;
                }
            }
            answerTextBox.Text = new String(helpChars);
            answerTextBox.SelectionStart = answerTextBox.Text.Length;
            SetEnebledWithRefresh(btn, true);
        }

        private void SetEnebledWithRefresh(Button btn, bool enabled)
        {
            btn.Enabled = enabled;
            btn.Refresh();
        }
    }
}

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
    public partial class WrittenQuizForm : Form
    {
        private const int TIMER_LIMIT = 10;
        private Timer timer;
        private MainController mContr;
        private int timeCounter;
        private string rightAnswer;
        private Color normalBackColor;
        private Color normalForeColor;
        public WrittenQuizForm(MainController mContr)
        {
            this.mContr = mContr;
            InitializeComponent();
            GetNextWordsPair();
            StatrTimer();
            this.FormClosing += delegate { timer.Stop(); timer.Dispose(); };
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
            KeyValuePair<string, string> pair = mContr.getRamdomWordsPair();
            questionTextBox.Text = pair.Key;
            questionTextBox.SelectAll();
            questionTextBox.SelectionAlignment = HorizontalAlignment.Center;
            questionTextBox.DeselectAll();
            rightAnswer = pair.Value;
        }

        private void StatrTimer()
        {
            timeCounter = 0;
            timerBar.Maximum = TIMER_LIMIT;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeCounter == TIMER_LIMIT)
            {
                WrongAnswer(answerTextBox, null);
                return;
            }
            timeCounter++;
            timerBar.Value = timeCounter;
        }
        private void WrongAnswer(object sender, EventArgs e)
        {
            Control tBox = sender as Control;
            normalBackColor = tBox.BackColor;
            normalForeColor = tBox.ForeColor;
            tBox.BackColor = Color.Red;
            tBox.ForeColor = Color.White;
            Reset();
        }

        private void AnswerTextBoxReset_Tick(object sender, EventArgs e)
        {
            Timer tmr = sender as Timer;
            tmr.Stop();
            tmr.Dispose();
            answerTextBox.BackColor = normalBackColor;
            answerTextBox.ForeColor = normalForeColor;
            answerTextBox.Text = String.Empty;
            answerTextBox.TextChanged += AnswerTextBox_TextChanged;
            answerTextBox.ReadOnly = false;
            GetNextWordsPair();
            timer.Start();
        }

        private void AnswerTextBox_TextChanged(object sender, EventArgs e)
        {
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
        }

        private void Reset()
        {
            answerTextBox.TextChanged -= AnswerTextBox_TextChanged;
            answerTextBox.ReadOnly = true;
            answerTextBox.Text = rightAnswer;
            timer.Stop();
            timeCounter = 0;
            timerBar.Value = timeCounter;
            Timer tmr = new Timer();
            tmr.Interval = 5000;
            tmr.Tick += AnswerTextBoxReset_Tick;
            tmr.Start();
        }
    }
}

using EnglishWhale.Controller;
using EnglishWhale.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWhale.View
{
    public partial class ChooseAnswerQuizForm : Form, IMute
    {
        private const int SECONDS = 10;
        private int timeCounter;
        private bool btnDisabled;
        private bool isTimerEnable;

        private MainController mContr;
        private Button rightAnswerBtn;
        private Timer answerTimer;
        public bool MuteQuestion { get; set; }
        public bool MuteAnswer { get; set; }
        public ChooseAnswerQuizForm(MainController mContr, bool timer)
        {
            InitializeComponent();
            this.mContr = mContr;
            mContr.SetMutes(this);
            isTimerEnable = timer;
            SetTimer(timer);
            this.FormClosing += ChooseAnswerQuizForm_FormClosing;
            GetQuestionAndAnswers();
        }

        private void ChooseAnswerQuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAnswerTimer();
        }

        private void SetTimer(bool isSet)
        {
            if (isSet)
            {
                timerBar.Maximum = SECONDS;
                timeCounter = 0;
                answerTimer = new Timer();
                answerTimer.Interval = 1000;
                answerTimer.Tick += TimerHandler;
                answerTimer.Start();
            }
            else
            {
                timerBar.Visible = false;
                timerLabel.Visible = false;
            }
        }
        private void StopAnswerTimer()
        {
            if (answerTimer != null)
            {
                answerTimer.Stop();
                answerTimer.Dispose();
            }
        }
        private void TimerHandler(object sender, EventArgs e)
        {
            if (timeCounter == SECONDS)
            {
                WrongAnswer(this, null);
                return;
            }
            timeCounter++;
            timerBar.Value = timeCounter;
        }

        private void SetQuestion(string question)
        {
            if (!MuteQuestion)
            {
                mContr.SpeakThis(question);
            }
            questionTextBox.Text = question;
            questionTextBox.SelectAll();
            questionTextBox.SelectionAlignment = HorizontalAlignment.Center;
            questionTextBox.DeselectAll();
        }

        private void SetAnswers(string rightAnswer, string answer2, string answer3, string answer4)
        {
            List<Button> bList = new List<Button>() { button1, button2, button3, button4 };

            Random rnd = new Random();
            int rightAnswerBtnPosition = rnd.Next(0, 3);

            rightAnswerBtn = bList[rightAnswerBtnPosition];
            rightAnswerBtn.Text = rightAnswer;
            rightAnswerBtn.Click += this.RightAnswer;
            rightAnswerBtn.MouseEnter += VolumeFromButton_MouseEnter;
            bList.RemoveAt(rightAnswerBtnPosition);


            Queue<Button> queueButtons = new Queue<Button>(bList);
            Button button = queueButtons.Dequeue();
            button.Text = answer2;
            button.Click += WrongAnswer;
            button.MouseEnter += VolumeFromButton_MouseEnter;

            button = queueButtons.Dequeue();
            button.Text = answer3;
            button.Click += WrongAnswer;
            button.MouseEnter += VolumeFromButton_MouseEnter;

            button = queueButtons.Dequeue();
            button.Text = answer4;
            button.Click += WrongAnswer;
            button.MouseEnter += VolumeFromButton_MouseEnter;
            this.Refresh();
        }

        private void WrongAnswer(object sender, EventArgs e)
        {
            if (btnDisabled) return;
            StopAnswerTimer();
            MakeAllButtonsDisabled();

            if (sender is Button)
            {
                Button wrongBtn = sender as Button;
                wrongBtn.MouseUp += delegate { wrongBtn.Image = Properties.Resources.button_back_bad; };
                wrongBtn.MouseLeave += delegate { wrongBtn.Image = Properties.Resources.button_back_bad; };
            }
            else
            {
                (sender as Form).BackgroundImage = Properties.Resources.background_2;
            }
            rightAnswerBtn.Image = Properties.Resources.button_back_good;
            Timer tm = new Timer();
            tm.Interval = 2000;
            tm.Tick += delegate {
                tm.Stop();
                ResetForm();
                tm.Dispose();
            };
            tm.Start();
            if (!MuteAnswer)
            {
                mContr.SpeakThis(rightAnswerBtn.Text);
            }
        }

        private void RightAnswer(object sender, EventArgs e)
        {
            if (btnDisabled) return;
            StopAnswerTimer();
            MakeAllButtonsDisabled();

            Button rightAnswerBtn = sender as Button;
            rightAnswerBtn.MouseUp += delegate { rightAnswerBtn.Image = Properties.Resources.button_back_good; };
            rightAnswerBtn.MouseLeave += delegate { rightAnswerBtn.Image = Properties.Resources.button_back_good; };

            Timer tm = new Timer();
            tm.Interval = 1500;
            tm.Tick += delegate {
                tm.Stop();
                ResetForm();
                tm.Dispose();
            };
            tm.Start();
            if (!MuteQuestion)
            {
                mContr.SpeakThis(questionTextBox.Text);
            }
        }

        private void VolumePic_MouseEnter(object sender, EventArgs e)
        {
            if (MuteQuestion) return;
            string phrase = questionTextBox.Text;
            mContr.SpeakThis(phrase);
        }

        private void VolumeFromButton_MouseEnter(object sender, EventArgs e)
        {
            if (MuteAnswer) return;
            Button btn = sender as Button;
            string phrase = btn.Text;
            mContr.SpeakThis(phrase);
        }

        private void MakeAllButtonsDisabled()
        {
            btnDisabled = true;
        }
        private void MakeAllButtonsEnabled()
        {
            btnDisabled = false;
        }
        private void ResetButtons()
        {
            this.Controls.Remove(GetButton4());
            this.Controls.Remove(GetButton3());
            this.Controls.Remove(GetButton2());
            this.Controls.Remove(GetButton1());

            button1 = null;
            button2 = null;
            button3 = null;
            button4 = null;

            this.Controls.Add(GetButton4());
            this.Controls.Add(GetButton3());
            this.Controls.Add(GetButton2());
            this.Controls.Add(GetButton1());
        }

        private void ResetForm()
        {
            ResetButtons();
            GetQuestionAndAnswers();
            MakeAllButtonsEnabled();
            SetTimer(isTimerEnable);
            this.BackgroundImage = Properties.Resources.background_1;
        }

        private void GetQuestionAndAnswers()
        {
            QuizWithAnswers quiz = mContr.GetNewChooseAnswerQuiz();
            SetQuestion(quiz.Question);
            SetAnswers(quiz.RightAnswer, quiz.Answer2, quiz.Answer3, quiz.Answer4);
        }
    }
}

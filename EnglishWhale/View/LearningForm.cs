using EnglishWhale.Controller;
using EnglishWhale.Models;
using EnglishWhale.Services;
using System;
using System.Windows.Forms;

namespace EnglishWhale.View
{
    public partial class LearningForm : Form, IMute
    {
        private MainController mContr;
        private LearningService learningService;

        public bool MuteQuestion { get ; set; }
        public bool MuteAnswer { get ; set; }

        public LearningForm(MainController mContr)
        {
            this.mContr = mContr;
            mContr.SetMutes(this);
            InitializeComponent();
            StartLearning();
        }

        private void StartLearning()
        {
            learningService =  mContr.GetLearningService();
            this.Controls.Add(GetShowWordPanel());
            ShowNextWordButton_Click(null, null);
            GetNextButton().Click += ShowNextWordButton_Click;
        }

        private void ShowNextWordButton_Click(object sender, EventArgs e)
        {
            if (!learningService.RoundFinish)
            {
                WordsPair pair = learningService.GetNextWord();
                GetQuestioLabel().Text = pair.Translation;
                GetAnswerLabel().Text = pair.Original;
                if (!MuteAnswer)
                {
                    mContr.SpeakThis(pair.Translation);
                }
                return;
            }
            else
            {
                StartMakeSentencePart();
                NextPairsForSentenceButton_Click(null, null);
            }
        }

        private void NextPairsForSentenceButton_Click(object sender, EventArgs e)
        {
            if (!learningService.RoundFinish)
            {
                WordsPair pair1 = learningService.GetNextWord();
                WordsPair pair2 = learningService.GetNextWord();
                GetFirstPhraseLabel().Text = pair1.Translation;
                GetSecondPhraseLabel().Text = pair2.Translation;
                if (!MuteAnswer)
                {
                    mContr.SpeakThis(pair1.Translation);
                    mContr.SpeakThis(pair2.Translation);
                }
            }
            else
            {
                StartWrittenPart();
                
            }
        }

        private void StartWrittenPart()
        {
            WrittenQuizPanel writtenQuizPanel = new WrittenQuizPanel(mContr,
                delegate (MainController mController)
                {
                    if (learningService.RoundFinish)
                    {
                        this.Close();
                        this.Dispose();
                        return null;
                    }
                    else
                    {
                        return learningService.GetNextWord();
                    }
                });
            this.Controls.Remove(GetMakeSentencePanel());
            ReloadForm();
            this.Controls.Add(writtenQuizPanel);
            writtenQuizPanel.MuteAnswer = MuteAnswer;
            writtenQuizPanel.MuteQuestion = MuteQuestion;
        }

        private void StartMakeSentencePart()
        {
            this.Controls.Remove(GetShowWordPanel());
            ReloadForm();
            this.Controls.Add(GetMakeSentencePanel());
            GetNextButton().Click += NextPairsForSentenceButton_Click;
        }

        private void VoicePicture_MouseEnter(object sender, System.EventArgs e)
        {
            string text = GetQuestioLabel().Text;
            mContr.SpeakThis(text);
        }

        private void PhraseLabel_MouseEnter(object sender, System.EventArgs e)
        {
            string text = ((Label)sender).Text;
            mContr.SpeakThis(text);
        }

        private void ReloadForm()
        {
            showWordPanel = null;
            voicePicture = null;
            answerLabel = null;
            questionLabel = null;
            nextButton = null;
            makeSentencePanel = null;
            titleLabel = null;
            secondPhraseLabel = null;
            firstPhraseLabel = null;
        }
    }
}

using EnglishWhale.Controller;
using EnglishWhale.Models;
using EnglishWhale.Services;
using System;
using System.Threading;
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
            mContr.SetMutesForLearningOnly(this);
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
                TextHorizontalAlignmentCenter(GetQuestioLabel());
                GetAnswerLabel().Text = pair.Original;
                TextHorizontalAlignmentCenter(GetAnswerLabel());
                if (!MuteQuestion)
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
                GetToolTip().SetToolTip(GetFirstPhraseLabel(), pair1.Original);
                GetToolTip().SetToolTip(GetSecondPhraseLabel(), pair2.Original);
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
                        if (learningService.LeriningFinish)
                        {
                            this.Close();
                            this.Dispose();
                            return null;
                        }

                    }
                    return learningService.GetNextWord();
                });
            this.Controls.Remove(GetMakeSentencePanel());
            ReloadForm();
            this.Controls.Add(writtenQuizPanel);
            writtenQuizPanel.MuteAnswer = !MuteAnswer;
            writtenQuizPanel.MuteQuestion = !MuteQuestion;
        }

        private void StartMakeSentencePart()
        {
            this.Controls.Remove(GetShowWordPanel());
            ReloadForm();
            this.Controls.Add(GetMakeSentencePanel());
            GetNextButton().Click += NextPairsForSentenceButton_Click;
        }

        private void VoicePicture_MouseEnter(object sender, EventArgs e)
        {
            string text = GetQuestioLabel().Text;
            if (!MuteQuestion)
            {
                mContr.SpeakThis(text);
            }
        }

        private void FirstVoicePic_MouseEnter(object sender, EventArgs e)
        {
            string text = GetFirstPhraseLabel().Text;
            if (!MuteQuestion)
            {
                mContr.SpeakThis(text);
            }
        }
        private void SecondVoicePic_MouseEnter(object sender, EventArgs e)
        {
            string text = GetSecondPhraseLabel().Text;
            if (!MuteQuestion)
            {
                mContr.SpeakThis(text);
            }
        }

        private void TextHorizontalAlignmentCenter(RichTextBox textBox)
        {
            textBox.SelectAll();
            textBox.SelectionAlignment = HorizontalAlignment.Center;
            textBox.DeselectAll();
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

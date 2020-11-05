using EnglishWhale.Controller;
using EnglishWhale.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWhale.View
{
    public partial class LearningForm : Form
    {
        private MainController mContr;
        private LearningService learningService;
        public LearningForm(MainController mContr)
        {
            this.mContr = mContr;
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
                KeyValuePair<string, string> pair = learningService.GetNextWord();
                GetQuestioLabel().Text = pair.Key;
                GetAnswerLabel().Text = pair.Value;
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
                KeyValuePair<string, string> pair1 = learningService.GetNextWord();
                KeyValuePair<string, string> pair2 = learningService.GetNextWord();
                GetFirstPhraseLabel().Text = pair1.Key;
                GetSecondPhraseLabel().Text = pair2.Key;
            }
            else
            {
                Close();
                Dispose();
            }
        }

        private void StartMakeSentencePart()
        {
            this.Controls.Remove(GetShowWordPanel());
            ReloadForm();
            this.Controls.Add(GetMakeSentencePanel());
            GetNextButton().Click += NextPairsForSentenceButton_Click;
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

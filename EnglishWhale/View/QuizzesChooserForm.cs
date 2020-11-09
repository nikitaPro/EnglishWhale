using EnglishWhale.Controller;
using EnglishWhale.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EnglishWhale.View
{
    public partial class QuizzesChooserForm : Form
    {
        private MainController mContr;
        public QuizzesChooserForm(MainController mContr)
        {
            InitializeComponent();
            this.mContr = mContr;
        }

        private void chooseAnswerButton_Click(object sender, EventArgs e)
        {
            LanguageDictionary languageDictionary = (LanguageDictionary)diretionComboBox.SelectedItem;
            mContr.StartChooseAnswerQuiz(languageDictionary, false, this);
        }

        private void chooseAnswerWithTimerButton_Click(object sender, EventArgs e)
        {
            LanguageDictionary languageDictionary = (LanguageDictionary)diretionComboBox.SelectedItem;
            mContr.StartChooseAnswerQuiz(languageDictionary, true, this);
        }

        public void Add(List<LanguageDictionary> listOfLanguageDictionries)
        {
            foreach(LanguageDictionary lDict in listOfLanguageDictionries)
            {
                diretionComboBox.Items.Add(lDict);
            }
            if(diretionComboBox.Items.Count > 0)
            {
                diretionComboBox.SelectedIndex = 0;
            }
        }

        private void writeAnswerButton_Click(object sender, EventArgs e)
        {
            LanguageDictionary languageDictionary = (LanguageDictionary)diretionComboBox.SelectedItem;
            mContr.StartWrittenQuiz(languageDictionary, this);
            
        }

        private void learningButton_Click(object sender, EventArgs e)
        {
            LanguageDictionary languageDictionary = (LanguageDictionary)diretionComboBox.SelectedItem;
            mContr.StartLearning(languageDictionary, this);
        }

    }
}

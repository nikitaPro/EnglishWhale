using EnglishWhale.Controller;
using EnglishWhale.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EnglishWhale
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

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back_mouse_enter;
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back;
        }

        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back_mouse_clicked;
            btn.ForeColor = System.Drawing.Color.Black;
        }

        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.Image = global::EnglishWhale.Properties.Resources.button_back;
            btn.ForeColor = System.Drawing.Color.White;
        }
    }
}

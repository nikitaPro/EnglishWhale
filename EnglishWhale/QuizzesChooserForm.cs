using EnglishWhale.Controller;
using EnglishWhale.Models;
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
            mContr.startChooseAnswerQuiz(languageDictionary);
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

    }
}

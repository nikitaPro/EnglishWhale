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
        public QuizzesChooserForm()
        {
            InitializeComponent();
        }

        private void chooseAnswerButton_Click(object sender, EventArgs e)
        {

        }

        public void Add(List<LanguageDictionary> listOfLanguageDictionries)
        {
            foreach(LanguageDictionary lDict in listOfLanguageDictionries)
            {
                diretionComboBox.Items.Add(lDict);
            }
        }

    }
}

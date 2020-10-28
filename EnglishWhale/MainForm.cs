using System;
using System.Windows.Forms;
using EnglishWhale.Controller;

namespace EnglishWhale
{
    public partial class MainForm : Form
    {
        private MainController mContr;
        public MainForm(MainController mContr)
        {
            InitializeComponent();
            this.mContr = mContr;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            string csvPath = mContr.ChooseCSVFile();
            if (csvPath  != null)
            {
                filePathTextBox.Text = csvPath;
                startButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string path = filePathTextBox.Text;
            mContr.OpenQuizzesChooser(path, this);
        }
    }
}

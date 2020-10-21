using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnglishWhale.Services;

namespace EnglishWhale
{
    public partial class MainForm : Form
    {
        private OpenFileDialog openFileDialog;
        public MainForm()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog.FileName;
                startButton.Enabled = true;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;
            CsvReader csvReader;
            if (File.Exists(path))
            {
                csvReader = new CsvReader(path);
            }
        }
    }
}

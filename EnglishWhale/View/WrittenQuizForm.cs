using EnglishWhale.Controller;
using EnglishWhale.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace EnglishWhale
{
    public partial class WrittenQuizForm : Form, IMute
    {
        private MainController mContr;
        public bool MuteQuestion { get { return writtenQuizPanel.MuteQuestion; } set { writtenQuizPanel.MuteQuestion = value; } }
        public bool MuteAnswer { get { return writtenQuizPanel.MuteAnswer; } set { writtenQuizPanel.MuteAnswer = value; } }
        public WrittenQuizForm(MainController mContr)
        {
            this.mContr = mContr;
            InitializeComponent();
        }

 
    }
}

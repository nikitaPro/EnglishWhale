using EnglishWhale.Controller;
using EnglishWhale.View;
using System;
using System.Windows.Forms;

namespace EnglishWhale
{
    static class Program
    {
        /// <summary>
        /// The main entry point to the application 
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainController mContr = new MainController();
            Application.Run(new MainForm(mContr));
        }
    }
}

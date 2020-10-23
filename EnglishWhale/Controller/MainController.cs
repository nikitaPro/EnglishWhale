using EnglishWhale.Models;
using EnglishWhale.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishWhale.Controller
{
    public class MainController
    {
        private LanguageDictionary currentDictionary;
        public string  ChooseCSVFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public void openQuizzesChooser(string path, MainForm mForm)
        {
            CsvReader csvReader;
            if (File.Exists(path))
            {
                csvReader = new CsvReader(path);
                QuizzesChooserForm qcForm = new QuizzesChooserForm(this);
                qcForm.Add(csvReader.Vocabularies);
                qcForm.FormClosed += delegate { mForm.Visible = true; };
                mForm.Visible = false;
                qcForm.Show();
            }
            else
            {
                MessageBox.Show(mForm, "Selected .csv file not found.", "File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void startChooseAnswerQuiz(LanguageDictionary languageDictionary)
        {
            currentDictionary = languageDictionary;
            ChooseAnswerQuizForm qcForm = new ChooseAnswerQuizForm(this);
            Random rnd = new Random();
            int testPairNumber = rnd.Next(0, languageDictionary.Dict.Count);
            KeyValuePair<string, string> testPair = languageDictionary.Dict.ElementAt(testPairNumber);
            string question = testPair.Key;
            string rightAnswer = testPair.Value;
            string[] wrongs = new string[3];
            for (int i = 0; i < 3; i++)
            {
                int wrongPairNumber;
                do
                {
                    wrongPairNumber = rnd.Next(0, languageDictionary.Dict.Count);
                } while (wrongPairNumber == testPairNumber);

                KeyValuePair<string, string> wrongPair = languageDictionary.Dict.ElementAt(wrongPairNumber);
                wrongs[i] = wrongPair.Value;
            }
            qcForm.setQuestion(question);
            qcForm.setAnswers(rightAnswer, wrongs[0], wrongs[1], wrongs[2]);
            qcForm.Show();
        }

        public void wrongChooseAnswer()
        {
            startChooseAnswerQuiz(currentDictionary);
        }
        public void rightChooseAnswer()
        {
            startChooseAnswerQuiz(currentDictionary);
        }
    }
}

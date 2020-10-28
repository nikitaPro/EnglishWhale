
using EnglishWhale.Models;
using EnglishWhale.Services;
using EnglishWhale.Services.DownloadService;
using EnglishWhale.Services.DownloadService.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace EnglishWhale.Controller
{
    public class MainController
    {
        private string tempPathForAudio;
        private LanguageDictionary currentDictionary;
        private WindowsMediaPlayer wplayer;
        IDownloader downloader;
        public MainController()
        {
            tempPathForAudio = Path.Combine(Path.GetTempPath(), @"audio");
            Console.WriteLine(tempPathForAudio);
            downloader = new DownloaderBufferedProxy();
        }

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

        public void OpenQuizzesChooser(string path, MainForm mForm)
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

        public void StartChooseAnswerQuiz(LanguageDictionary languageDictionary)
        {
            currentDictionary = languageDictionary;
            ChooseAnswerQuizForm qcForm = new ChooseAnswerQuizForm(this);
            if (currentDictionary.IsEnglishFrom)
            {
                qcForm.MuteQuestion = false;
            } 
            else if (currentDictionary.IsEnglishTo)
            {
                qcForm.MuteAnswer = false;
            }

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

        public void WrongChooseAnswer()
        {
            StartChooseAnswerQuiz(currentDictionary);
        }
        public void RightChooseAnswer()
        {
            StartChooseAnswerQuiz(currentDictionary);
        }

        public void SpeakThis(string phrase)
        {

            string voicePath = downloader.DownloadVoice(phrase, tempPathForAudio);

            IWMPControls3 controls;
            if (wplayer != null)
            {
                do
                {
                    controls = (IWMPControls3)wplayer.controls;
                    if (controls.get_isAvailable("stop"))
                    {
                        controls.stop();
                    }
                    Thread.Sleep(100);
                } while (wplayer.playState == WMPPlayState.wmppsPlaying);
                
            }
            wplayer = new WindowsMediaPlayer();

            wplayer.URL = voicePath;
            controls = (IWMPControls3)wplayer.controls;
            controls.play();

            wplayer.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Wplayer_StatusChange);
            wplayer.MediaError += new _WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);

        }

        private void Wplayer_StatusChange(int newState)
        {
            if (newState != (int)WMPPlayState.wmppsPlaying)
            {
                IWMPPlaylist playList = wplayer.mediaCollection.getAll();
                if (playList.count >= 1) 
                {
                    IWMPMedia3 media = (IWMPMedia3)playList.get_Item(0);
                    wplayer.mediaCollection.remove(media, true);
                }
                wplayer.close();
            }
        }
        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            wplayer.close();
        }

    }
}

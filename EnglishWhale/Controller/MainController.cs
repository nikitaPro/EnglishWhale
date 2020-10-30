
using EnglishWhale.Models;
using EnglishWhale.Services;
using EnglishWhale.Services.DownloadService;
using EnglishWhale.Services.DownloadService.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace EnglishWhale.Controller
{
    public class MainController
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private string tempPathForAudio;
        private LanguageDictionary currentDictionary;
        private WindowsMediaPlayer wplayer;
        private bool isTimerNeeded;
        private Random rnd;
        IDownloader downloader;
        public MainController()
        {
            tempPathForAudio = Path.Combine(Path.GetTempPath(), @"audio");
            downloader = new DownloaderBufferedProxy();
            rnd = new Random();
        }

        public string ChooseCSVFile()
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

        internal void StartWrittenQuiz(LanguageDictionary languageDictionary)
        {
            currentDictionary = languageDictionary;
            new WrittenQuizForm(this).Show();
        }

        internal KeyValuePair<string, string> getRamdomWordsPair()
        {
            int testPairNumber = rnd.Next(0, currentDictionary.Dict.Count);
            return currentDictionary.Dict.ElementAt(testPairNumber);
        }

        public void StartChooseAnswerQuiz(LanguageDictionary languageDictionary, bool timer)
        {
            isTimerNeeded = timer;
            currentDictionary = languageDictionary;
            ChooseAnswerQuizForm qcForm = new ChooseAnswerQuizForm(this, timer);
            if (currentDictionary.IsEnglishFrom)
            {
                qcForm.MuteQuestion = false;
            } 
            else if (currentDictionary.IsEnglishTo)
            {
                qcForm.MuteAnswer = false;
            }

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

        public bool isRightAnswer(string rightAnswer, string userAnswer)
        {
            string[] answers = rightAnswer.Split(';');
            foreach (string rightAns in answers)
            {
                if (rightAns.Trim().ToLower().Equals(userAnswer))
                {
                    return true;
                }
            }
            return false;
        }

        public void WrongChooseAnswer()
        {
            StartChooseAnswerQuiz(currentDictionary, isTimerNeeded);
        }
        public void RightChooseAnswer()
        {
            StartChooseAnswerQuiz(currentDictionary, isTimerNeeded);
        }

        public void SpeakThis(string phrase)
        {
            string voicePath;
            try
            {
                voicePath = downloader.DownloadVoice(phrase, tempPathForAudio);
            }
            catch (WebException ex)
            {
                Logger.Error(ex, "Unable to download voice.");
                return;
            }

            WaitingStopPlayer();
            PlayVoiceFile(voicePath);
        }
        private void PlayVoiceFile(string voicePath)
        {
            wplayer = new WindowsMediaPlayer();

            wplayer.URL = voicePath;
            IWMPControls3 controls = (IWMPControls3)wplayer.controls;
            controls.play();

            wplayer.PlayStateChange += new _WMPOCXEvents_PlayStateChangeEventHandler(Wplayer_StatusChange);
            wplayer.MediaError += new _WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
        }
        private void WaitingStopPlayer()
        {
            IWMPControls3 controls;
            if (wplayer != null)
            {
                do
                {
                    controls = (IWMPControls3)wplayer.controls;
                    double lastPosition = controls.currentPosition;
                    Thread.Sleep(100);
                    bool payngPositionChanged = (controls.currentPosition - lastPosition) > 0.001;
                    if (!payngPositionChanged)
                    {
                        if (controls.get_isAvailable("stop"))
                        {
                            controls.stop();
                        }
                    }
                } while (wplayer.playState == WMPPlayState.wmppsPlaying);

            }
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

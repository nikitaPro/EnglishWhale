using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnglishWhale.Services.DownloadService.Implementation
{
    public class DownloaderBufferedProxy : IDownloader
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private string phraseBuffNorm;
        private string phraseBuffSlow;
        private string voicePathNorm;
        private string voicePathSlow;
        private IDownloader downloaderNorm;
        private IDownloader downloaderSlow;
        private Thread fileCleaner;
        private Queue<string> garbageQueue;
        private bool speakFast;

        public DownloaderBufferedProxy()
        {
            downloaderNorm = new Downloader(1.0);
            downloaderSlow = new Downloader(0.24);
            garbageQueue = new Queue<string>();
            speakFast = true;
        }

        public string DownloadVoice(string phrase, string folder)
        {
            if (String.IsNullOrWhiteSpace(phrase))
            {
                throw new ArgumentNullException("Phrase cannot be null or empty");
            }
            if (folder == null)
            {
                folder = String.Empty;
            }

            speakFast = phrase.Equals(phraseBuffNorm) ? !speakFast : true;

            return speakFast 
                ? Download(phrase, ref phraseBuffNorm, ref voicePathNorm, folder, downloaderNorm) 
                : Download(phrase, ref phraseBuffSlow, ref voicePathSlow, folder, downloaderSlow);

        }

        private int counter;
        private const int MAX_ATTEMPTS = 50;
        private void DeleteFilesAsSoonAsPossible()
        {
            counter = 0;
            while (garbageQueue.Count > 0)
            {
                if (counter > MAX_ATTEMPTS)
                {
                    fileCleaner = null;
                    Logger.Trace("Exit attempts run out");
                    return;
                }
                counter++;

                string filePath = garbageQueue.Dequeue();
                try
                {
                    if (!String.IsNullOrWhiteSpace(filePath))
                    {
                        File.Delete(filePath);
                        Thread.Sleep(200);
                        if (File.Exists(filePath))
                        {
                            throw new IOException("File did not removed");
                        }
                    }
                }
                catch (Exception e)
                {
                    garbageQueue.Enqueue(filePath);
                }
            }
            Logger.Trace("Exit with empty queue");
            fileCleaner = null;
        }

        private string Download(string phrase, ref string phraseBuff, ref string voicePath, string folder, IDownloader downloader)
        {
            if (!phrase.Equals(phraseBuff) || !File.Exists(voicePath))
            {
                phraseBuff = phrase;
                garbageQueue.Enqueue(voicePath);
                voicePath = downloader.DownloadVoice(phrase, folder);
                if (fileCleaner == null)
                {
                    fileCleaner = new Thread(DeleteFilesAsSoonAsPossible);
                    fileCleaner.Start();
                }
            }

            return voicePath;
        }
        ~DownloaderBufferedProxy()
        {
            garbageQueue.Enqueue(voicePathNorm);
            garbageQueue.Enqueue(voicePathSlow);
            DeleteFilesAsSoonAsPossible();
        }
    }
}

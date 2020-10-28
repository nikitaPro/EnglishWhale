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
        private string phraseBuff;
        private string voicePath;
        private IDownloader downloader;
        private Thread fileCleaner;
        private Queue<string> garbageQueue;

        public DownloaderBufferedProxy()
        {
            downloader = new Downloader();
            garbageQueue = new Queue<string>();
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

        private int counter;
        private const int MAX_ATTEMPTS = 200;
        private void DeleteFilesAsSoonAsPossible()
        {
            counter = 0;
            while (garbageQueue.Count > 0)
            {
                if (counter > MAX_ATTEMPTS)
                {
                    fileCleaner = null;
                    Console.WriteLine("Exit attempts run out");
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
                    Console.WriteLine(e.StackTrace);
                    garbageQueue.Enqueue(filePath);
                }
            }
            Console.WriteLine("Exit with empty queue");
            fileCleaner = null;
        }
        ~DownloaderBufferedProxy()
        {
            garbageQueue.Enqueue(voicePath);
            DeleteFilesAsSoonAsPossible();
        }
    }
}

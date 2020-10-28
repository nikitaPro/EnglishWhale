using System;
using System.IO;
using System.Net;

namespace EnglishWhale.Services.DownloadService.Implementation
{
    public class Downloader : IDownloader
    {
        private WebClient webClient;
        public Downloader()
        {
            webClient = new WebClient();
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

            Directory.CreateDirectory(folder);

            Random rnd = new Random();
            string fileName;
            string filePath;
            do 
            {
                fileName = $"Voice_{rnd.Next()}{rnd.Next()}.mp3";
                filePath = Path.Combine(folder, fileName);
            } while (File.Exists(filePath));
            
            webClient.DownloadFile(String.Format("https://translate.google.com.vn/translate_tts?ie=UTF-8&q={0}&tl=en&client=tw-ob", phrase), filePath);
            return filePath;
        }

    }
}

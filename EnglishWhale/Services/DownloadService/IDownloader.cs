namespace EnglishWhale.Services.DownloadService
{
    interface IDownloader
    {
        string DownloadVoice(string phrase, string folder);
    }
}

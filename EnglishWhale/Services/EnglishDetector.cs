using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EnglishWhale.Services
{
    public class EnglishDetector
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private const string TEMPLATE_HTTPS = "https://translate.googleapis.com/translate_a/single?client=gtx&sl=auto&tl=en&dt=t&q={0}";
        private WebClient web;
        public EnglishDetector()
        {
            web = new WebClient();
            web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
            web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");
            // Make sure we have response encoding to UTF-8
            web.Encoding = Encoding.UTF8;
        }
        public bool isTheDirectionEnglish(string translateDirection)
        {
            if (translateDirection == null)
            {
                throw new ArgumentNullException("Translate direction cannot be null!"); 
            }
            if ("english".Equals(translateDirection.ToLower()))
            {
                return true;
            }

            string restQuery = String.Format(TEMPLATE_HTTPS, translateDirection);
            string translationJson;
            try
            {
                translationJson = web.DownloadString(restQuery);
            }
            catch (WebException ex)
            {
                Logger.Error(ex, "Unable determine the language, because web request failed.");
                throw;
            }

            List<dynamic> jsonData = JsonConvert.DeserializeObject<List<dynamic>>(translationJson);
            string language = jsonData[0][0][0];

            return "english".Equals(language.ToLower());
        }
    }
}

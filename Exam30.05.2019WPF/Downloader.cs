using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exam30._05._2019WPF
{
    public class Downloader : IDownloader
    {
        private readonly ILogger logger;
        public Downloader(ILogger logger)
        {
            this.logger = logger;
        }

        public string DownloadRawJsonData(string url)
        {
            using (var client = new WebClient())
            {
                try
                {
                    logger.LoginMessage($"Request {url}");
                    return client.DownloadString(url);
                }
                catch (WebException exception)
                {
                    logger.LoginError(exception);
                    return "";
                }

            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAdvert.SearchWorker
{
    internal class ConfigurationHelper
    {
        private static IConfiguration _configuration = null;

        public static IConfiguration Instance
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetCurrentDirectory())
                                            .AddJsonFile("appsettings.json")
                                            .Build();
                }

                return _configuration;
            }
        }
    }
}

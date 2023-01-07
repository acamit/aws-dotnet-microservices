using Microsoft.Extensions.Configuration;
using Nest;

namespace WebAdvert.SearchWorker
{
    public class ElasticSearchHelper
    {
        private static IElasticClient _client;

        public static IElasticClient GetInstance(IConfiguration configuration)
        {
            if(_client == null)
            {
                var url = configuration.GetSection("ES").GetValue<string>("url");
                var settings = new ConnectionSettings(new System.Uri(url)).DefaultIndex("adverts");
                _client = new ElasticClient(settings);
            }
            return _client;

        }
    }
}

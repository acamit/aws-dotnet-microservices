using AdvertApi.Models;
using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Nest;
using Newtonsoft.Json;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    public class SearchWorker
    {
        private readonly IElasticClient _elasticClient;

        // be default this constructor will be called for lambda. So we use constructor inheritance to call the other constructor.
        public SearchWorker() : this(ElasticSearchHelper.GetInstance(ConfigurationHelper.Instance))
        {

        }

        public SearchWorker(IElasticClient client)
        {
            _elasticClient = client;
        }

        // lambda context is optional. But it gives us some context about function and access to cloud watch to log data
        public async Task Function(SNSEvent snsEvent, ILambdaContext context)
        {
            foreach (var record in snsEvent.Records)
            {
                // Log the message. 
                context.Logger.LogLine(record.Sns.Message);

                var message = JsonConvert.DeserializeObject<AdvertModel>(record.Sns.Message);
                var advertDoc = MappingHelper.Map(message);

                await _elasticClient.IndexDocumentAsync(advertDoc);
            }
        }
    }
}

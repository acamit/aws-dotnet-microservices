using AdvertApi.Models;
using Advertising.Models;
using AutoMapper;
using Newtonsoft.Json;

namespace Advertising.ServiceClient
{
    public class AdvertApiClient : IAdvertApiClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AdvertApiClient(IConfiguration configuration, HttpClient client, IMapper mapper)
        {
            _client = client;
            _configuration = configuration;
            _mapper = mapper;

            var baseUrl = _configuration.GetSection("AdvertApi").GetValue<string>("BaseUrl");
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Add("Content-type", "application/json");
        }

        public async Task<bool> Confirm(ConfirmAdvertRequest confirmAdvertModel)
        {
            var advertModel = _mapper.Map<ConfirmAdvertModel>(confirmAdvertModel);
            var jsonModel = JsonConvert.SerializeObject(advertModel);
            var response = await _client.PutAsync(new Uri($"{_client.BaseAddress}/confirm"), new StringContent(jsonModel)).ConfigureAwait(false);
            return response.IsSuccessStatusCode;
        }

        public async Task<CreateAdventResponseModel> Create(CreateAdvertModel advertModel)
        {
            var advertApiModel = _mapper.Map<AdvertModel>(advertModel);
            var jsonModel = JsonConvert.SerializeObject(advertApiModel);
            var response = await _client.PostAsync(new Uri($"{_client.BaseAddress}/create"), new StringContent(jsonModel));
            var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var createAdvertResponse = JsonConvert.DeserializeObject<CreateAdventResponse>(responseJson);
            return _mapper.Map<CreateAdventResponseModel>(createAdvertResponse);

        }
    }
}

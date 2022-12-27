using AdvertApi.Models;
using AdvertAPI.Services.Interfaces;

namespace AdvertAPI.Services
{
    public class DynamoDbAdvertStorage : IAdvertStorageService
    {
        public Task<string> Add(AdvertModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Confirm(ConfirmAdvertModel model)
        {
            throw new NotImplementedException();
        }
    }
}

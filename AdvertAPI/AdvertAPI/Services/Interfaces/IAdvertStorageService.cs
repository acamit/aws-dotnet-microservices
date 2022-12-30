using AdvertApi.Models;

namespace AdvertAPI.Services.Interfaces
{
    public interface IAdvertStorageService
    {
        Task<string> Add(AdvertModel model);

        Task Confirm(ConfirmAdvertModel model);

        Task<bool> CheckHealthAsync();
    }
}

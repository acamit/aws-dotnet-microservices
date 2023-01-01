using Advertising.Models;

namespace Advertising.ServiceClient
{
    public interface IAdvertApiClient
    {
        Task<CreateAdventResponseModel> Create(CreateAdvertModel advertModel);
        Task<bool> Confirm(Models.ConfirmAdvertRequest confirmAdvertModel);
    }
}

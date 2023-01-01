using AdvertApi.Models.Enums;

namespace Advertising.Models
{
    public class ConfirmAdvertRequest
    {
        public string Id { get; set; }

        public AdvertStatus Status { get; set; }
    }
}

using Advertising.ServiceClient;
using Microsoft.AspNetCore.Mvc;

namespace Advertising.Controllers
{
    public class AdvertManagementController : Controller
    {
        private readonly IAdvertApiClient _advertApiClient;

        public AdvertManagementController(IAdvertApiClient advertApiClient)
        {
            _advertApiClient = advertApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

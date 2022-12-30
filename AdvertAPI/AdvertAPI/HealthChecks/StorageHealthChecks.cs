using AdvertAPI.Services.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace AdvertAPI.HealthChecks
{
    public class StorageHealthChecks : IHealthCheck
    {
        private readonly IAdvertStorageService _storageService;

        public StorageHealthChecks(IAdvertStorageService storageService) {
            _storageService = storageService;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isStorageOk = await _storageService.CheckHealthAsync();
            return isStorageOk? HealthCheckResult.Healthy():HealthCheckResult.Unhealthy();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace ProductsApi.Controllers;

[Route("/")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    private readonly ILogger<HealthCheckController> _logger;
    private readonly Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService _service;

    public HealthCheckController(ILogger<HealthCheckController> logger, Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var report = await _service.CheckHealthAsync();

        _logger.LogInformation($"Get Health Information: {report}");

        /* HealthCheck Status:
         * 0 Unhealthy
         * 1 Degraded
         * 2 Unhealthy */

        return report.Status == HealthStatus.Healthy ? Ok(report) : StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
    }
}

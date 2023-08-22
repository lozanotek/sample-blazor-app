using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Shared;

namespace SampleApp.Server.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ClaimsController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public ClaimsController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<ClaimInfo> Get()
    {
        var userClaims = User.Claims.ToArray();
        return userClaims.Select(c => new ClaimInfo { Name = c.Type, Value = c.Value } ).ToArray();
    }
}

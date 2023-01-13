using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SecretsManager.API.SecretsManager.Options;

namespace SecretsManager.API.Controllers;

[Route("api/secrets")]
[ApiController]
public class SecretsController : ControllerBase
{

    private readonly ConnectionStringsOptions _optionsConnection;
    private readonly TokenConfigurationsOptions _optionsToken;

    public SecretsController(IOptions<ConnectionStringsOptions> optionsConnection, IOptions<TokenConfigurationsOptions> optionsToken)
    {
        _optionsConnection = optionsConnection.Value;
        _optionsToken = optionsToken.Value;
    }

    // GET: api/Secrets
    /// <summary>
    /// Obtêm os segredos
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok($"Retorno: {_optionsConnection.DefaultConnection} | {_optionsToken.SecretJWTKey}");
    }

}

using auth_api.Config;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Domain.Controllers;

[ApiController]
[Route("health")]
public class HealthController(PostgresContext context)
{
    private readonly PostgresContext _context = context;
    
    public record HealthResponse(string Status);
    
    [HttpGet(Name = "health")]
    public HealthResponse GetHealth()
    {
        if (!_context.Database.CanConnect())
        {
            throw new Exception($"Cannot connect to database");
        }
        return new HealthResponse("I'm alive");
    }
}
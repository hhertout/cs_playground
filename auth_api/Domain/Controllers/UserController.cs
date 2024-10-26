using auth_api.Domain.ValueObject;
using auth_api.Infra.DataLayer;
using auth_api.Infra.Entity;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Domain.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(ILogger<UserController> logger, IDataLayer<UserEntity> dataLayer) : ControllerBase
{
    private readonly IDataLayer<UserEntity> _dataLayer = dataLayer;
    private readonly ILogger<UserController> _logger = logger;
    
    [HttpGet(Name = "GetUsers")]
    public IEnumerable<UserEntity> GetUsers()
    {
        return _dataLayer.GetAll();
    }

    [HttpPost(Name = "AddUser")]
    public IActionResult AddUser([FromBody] CreateUserValueObj user)
    {
        try
        {
            if (string.IsNullOrEmpty(user.Email)) return BadRequest(new { message = "email is empty" });
            if (string.IsNullOrEmpty(user.Password)) return BadRequest(new { message = "password is empty" });
            
            _logger.LogDebug("Adding user {User}", user.Email);
            _dataLayer.Persist(new UserEntity(user.Email, user.Password));
            
            return Created("AddUser", new { message = "success" });
        }
        catch (Exception err)
        {
            return Problem(err.Message, statusCode: 500);
        }
        
    }
}
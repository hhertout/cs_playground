using auth_api.App.Jwt;
using auth_api.Domain.Dto;
using auth_api.Infra.DataLayer;
using auth_api.Infra.Entity;
using auth_api.Infra.ValueObj;
using Microsoft.AspNetCore.Mvc;

namespace auth_api.Domain.Controllers;

[ApiController]
[Route("api/user")]
public class UserController(ILogger<UserController> logger, IDataLayer dataLayer) : ControllerBase
{
    private readonly IDataLayer _dataLayer = dataLayer;
    private readonly ILogger<UserController> _logger = logger;

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<IValueObj> GetUsers()
    {
        return _dataLayer.GetAll();
    }

    [HttpPost(Name = "AddUser")]
    public IActionResult Register([FromBody] CreateUserArgs body)
    {
        try
        {
            if (string.IsNullOrEmpty(body.Email)) return BadRequest(new { message = "email is empty" });
            if (string.IsNullOrEmpty(body.Password)) return BadRequest(new { message = "password is empty" });

            _logger.LogDebug("Adding user {User}", body.Email);
            _dataLayer.Persist(new CreateUserValueObj(body.Email, body.Password));

            return Created("AddUser", new { message = "success" });
        }
        catch (Exception err)
        {
            return Problem(err.Message, statusCode: 500);
        }
    }

    public IActionResult Login([FromBody] LoginBodyArgs loginArgs)
    {
        try
        {
            if (string.IsNullOrEmpty(loginArgs.Username) || string.IsNullOrEmpty(loginArgs.Password))
            {
                return BadRequest(new { message = "username or password is empty" });
            }

            JwtService jwtService = new();
            
            return Ok(new
            {
                user = loginArgs.Username,
                token = jwtService.GenerateToken(loginArgs.Username)
            });
        }
        catch (Exception err)
        {
            return Problem(err.Message, statusCode: 500);
        }
    }
}
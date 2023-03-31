using Auth.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers;

// [ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    IUserService userservice;

    public UserController(IUserService service){
        userservice = service;
    }
    
    [HttpGet]
    public IActionResult Get(){
        return Ok(userservice.Get());
    }
}
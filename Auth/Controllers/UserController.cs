using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using Auth.Services;

namespace Auth.Controllers;

[ApiController]
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
        // return Ok(userservice.Get());
    }

    // [HttpGet("{id}")]
    // public IActionResult GetById(Guid id){
    //     return Ok(userservice.GetById(id));
    // }

    [HttpPost]
    public IActionResult Create([FromBody] User user )
    {
        Console.WriteLine(user);
        userservice.Create(user);
        return Ok();
    }
}
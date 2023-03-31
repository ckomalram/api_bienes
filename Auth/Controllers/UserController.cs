using Auth.Models;
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
    public IEnumerable<User> Get(){
        return userservice.Get();
        // return Ok(userservice.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id){
        return Ok(userservice.GetById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] User user ){

        userservice.Create(user);
        return Ok();
    }
}
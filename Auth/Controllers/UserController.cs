using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using Auth.Services;

namespace Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    IUserService userservice;

    public UserController(IUserService service)
    {
        userservice = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(userservice.Get());
        // return Ok(userservice.Get());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var rta = await userservice.GetById(id);
        return Ok(rta);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        // Console.WriteLine(user);
        var rta = await userservice.Create(user);
        return Ok(rta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] User user)
    {
        // Console.WriteLine(user);
        await userservice.Update(id, user);
        return Ok("Actualizado!!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        // Console.WriteLine(user);
        await userservice.Delete(id);
        return Ok("Eliminado correctamente!");
    }
}


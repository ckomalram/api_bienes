using Microsoft.AspNetCore.Mvc;
using Auth.Models;
using Auth.Services;

namespace Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    ICustomerService customerservice;

    public CustomerController(ICustomerService service)
    {
        customerservice = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(customerservice.Get());
        // return Ok(customerservice.Get());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var rta = await customerservice.GetById(id);
        return Ok(rta);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        var rta = await customerservice.Create(customer);
        return Ok(rta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Customer customer)
    {
        await customerservice.Update(id, customer);
        return Ok("Actualizado!!");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await customerservice.Delete(id);
        return Ok("Eliminado correctamente!");
    }
}


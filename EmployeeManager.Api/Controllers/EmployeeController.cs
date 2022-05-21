using EmployeeManager.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(ILogger<EmployeeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return Created("", result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] EditEmployeeCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
}
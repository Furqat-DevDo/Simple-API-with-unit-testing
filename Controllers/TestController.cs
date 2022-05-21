using Lesson1.Core.IConfiguration;
using Lesson1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson1.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IUnitofWork _unitof;
    private readonly ILogger<TestController> _logger;

    public TestController(IUnitofWork unitof,ILogger<TestController> logger)
    {
        _unitof = unitof;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        if(ModelState.IsValid)
        {
            user.ID = new Guid ();
            await _unitof.Users.Add(user);
            await _unitof.CompleteAsync();
            return CreatedAtAction("Getitem",new {user.ID},user);
        }
        return new JsonResult("Something went wrong"){StatusCode=500};
    }
    [HttpGet("{id}")]
    public async Task<IActionResult>Getitem(Guid id)
    {
        var user = await _unitof.Users.GetByID(id);
        if(user==null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}

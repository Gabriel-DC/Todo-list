using Microsoft.AspNetCore.Mvc;

namespace Todo.Api.Controllers;

[ApiController]
[Route("/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult GetHelloWorld()
    {
        return Ok(new { Message = "Sucesso ao rodar a aplicação", Version = "Latest" });
    }
}
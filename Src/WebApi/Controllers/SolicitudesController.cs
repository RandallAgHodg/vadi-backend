using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/solicitudes")]
public class SolicitudesController : ApiController
{
    public SolicitudesController(IMediator sender) : base(sender)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(new { id });
    }
}

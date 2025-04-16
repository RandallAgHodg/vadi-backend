using Application.Features.Estados.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public sealed class EstadosController : ApiController
{
    public EstadosController(IMediator sender) : base(sender)
    {
    }

    [HttpGet(ApiRoutes.Estados.GetAll)]
    public async Task<IActionResult> Get()
    {
        var data = await Sender.Send(new GetAllEstadosQuery());

        return Ok(data);
    }
}

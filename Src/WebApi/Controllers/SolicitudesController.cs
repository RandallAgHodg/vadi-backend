using Application.Common.DataAccess;
using Application.Features.Request.Queries;
using Application.Features.Solicitudes.Commands.UpdateSolicitud;
using Application.Features.Solicitudes.Queries.GetSolicitudByQuerySearch;
using Application.Mapping;
using Domain.Common.Contracts.Data;
using Domain.Common.Contracts.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class SolicitudesController : ApiController
{
    private readonly ISolicitudRepository _solicitudRepository;
    
    public SolicitudesController(IMediator sender, ISolicitudRepository solicitudRepository) : base(sender) =>
        _solicitudRepository = solicitudRepository;
    

    [HttpGet(ApiRoutes.Solicitudes.GetAll)]
    public async Task<IActionResult> Get()
    {   
        var data = await Sender.Send(new GetAllSolicitudesQuery());

        return Ok(data);
    }

    [HttpGet(ApiRoutes.Solicitudes.Search)]
    public async Task<IActionResult> Get([FromQuery]string querySearch)
    {
        var data = await Sender.Send(new GetSolicitudByQuerySearch(querySearch));

        return Ok(data);
    }

    [HttpPost(ApiRoutes.Solicitudes.Create)]
    public async Task<IActionResult> Post([FromBody] CreateSolicitudRequest request)
    {
        var data = await Sender.Send(request.ToSolicitudCommand());

        return Ok(data);
    }

    [HttpPut(ApiRoutes.Solicitudes.Update)]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateSolicitudRequest request)
    {
        var data = await Sender.Send(request.ToSolicitudCommand(id));

        return Ok(data);
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
public abstract class ApiController: ControllerBase
{
    protected IMediator Sender { get; }

    protected ApiController(IMediator sender)
    {
        Sender = sender;
    }
}

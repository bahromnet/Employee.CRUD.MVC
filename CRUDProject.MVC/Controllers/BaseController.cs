using Application.MVC.Commons.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUDProject.MVC.Controllers;

public class BaseController : Controller
{
    protected IMediator mediator
        => HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected IApplicationDbContext context
        => HttpContext.RequestServices.GetRequiredService<IApplicationDbContext>();
}

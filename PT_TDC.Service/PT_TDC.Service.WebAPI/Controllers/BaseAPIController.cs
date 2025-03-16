using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PT_TDC.Service.WebAPI.Controllers
{
    [ApiController]
    [Route("api/EndPoint/[controller]")]
    public class BaseAPIController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}

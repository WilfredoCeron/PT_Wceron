using Microsoft.AspNetCore.Mvc;
using PT_TDC.Service.Application.Features.Parameters;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;

namespace PT_TDC.Service.WebAPI.Controllers.EndPoint
{
    public class ParametersController: BaseAPIController
    {
        [HttpGet("GetConfigurableParameters")]
        [ProducesResponseType(typeof(ObjectResponse<ParametersResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> GetParameters([FromQuery] GetParametersQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error al intentar obtener los parámetros " + ex.Message);
            }
        }
    }
}

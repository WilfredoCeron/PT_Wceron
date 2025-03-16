using Microsoft.AspNetCore.Mvc;
using PT_TDC.Service.Application.Features.CardInfo;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;

namespace PT_TDC.Service.WebAPI.Controllers.EndPoint
{
    public class CardController : BaseAPIController
    {
        [HttpGet("GetInfoCard")]
        [ProducesResponseType(typeof(ObjectResponse<GetInfoCardResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> GetInfoCard([FromQuery] GetInfoCardQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error al intentar obtener la información de la tarjeta " + ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;

namespace PT_TDC.Service.WebAPI.Controllers.EndPoint
{
    public class TransactionController : BaseAPIController
    {
        [HttpGet("GetHistoryTransactions")]
        [ProducesResponseType(typeof(ObjectResponse<GetHistoryTransactionsResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> GetHistoryTransactions([FromQuery] GetHistoryTransactionsQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error al intentar obtener la información de las transacciones de la tarjeta " + ex.Message);
            }
        }

        [HttpGet("GetHistoryBuy")]
        [ProducesResponseType(typeof(ObjectResponse<GetHistoryBuyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> GetHistoryBuy([FromQuery] GetHistoryBuyQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error al intentar obtener la información de las compras de la tarjeta " + ex.Message);
            }
        }

        [HttpGet("GetHistoryPayment")]
        [ProducesResponseType(typeof(ObjectResponse<GetHistoryPaymentResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> GetHistoryPayment([FromQuery] GetHistoryPaymentQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error al intentar obtener la información de los pagos de la tarjeta " + ex.Message);
            }
        }

        [HttpPost("CreateNewBuy")]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateNewBuy([FromBody] CreateNewBuyQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error al intentar guardar la información sobre la compra realizada " + ex.Message);
            }
        }

        [HttpPost("CreateNewPayment")]
        [ProducesResponseType(typeof(GenericResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse))]
        public async Task<IActionResult> CreateNewPayment([FromBody] CreateNewPaymentQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ha ocurrido un error al intentar guardar la información sobre el pago realizada " + ex.Message);
            }
        }
    }
}

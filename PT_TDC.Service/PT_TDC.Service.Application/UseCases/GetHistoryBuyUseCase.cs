using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.Service.Application.Interfaces.Queries;
using PT_TDC.Service.Application.UseCases.Interfaces;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.UseCases
{
    public class GetHistoryBuyUseCase : IGetHistoryBuyUseCase
    {
        private readonly IGetHistoryBuyQueries _historyBuyQueries;

        public GetHistoryBuyUseCase(IGetHistoryBuyQueries historyBuyQueries)
        {
            _historyBuyQueries = historyBuyQueries;
        }

        public async Task<ObjectResponse<List<GetHistoryBuyResponse>>> GetHistoryBuy(GetHistoryBuyQuery history)
        {
            ObjectResponse<List<GetHistoryBuyResponse>> response = new ObjectResponse<List<GetHistoryBuyResponse>>();
            response.Code = 0;
            response.Msj = "Hubo un error al intentar obtener la información de las compras de la tarjeta de crédito";

            var request = await _historyBuyQueries.GetHistoryBuy(history);

            try
            {
                if (request != null)
                {
                    response.Code = 1;
                    response.Msj = "Éxito";
                    response.Item = request.ToList();
                }
                else
                {
                    response.Code = 0;
                    response.Msj = "No existen compras con el número de tarjeta de crédito y el mes ingresado";
                }
            }
            catch (Exception ex)
            {

                response.Msj = "Error: " + ex.Message;
            }

            return response;
        }
    }
}

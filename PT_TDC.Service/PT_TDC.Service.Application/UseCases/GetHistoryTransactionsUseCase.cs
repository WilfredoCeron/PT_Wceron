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
    public class GetHistoryTransactionsUseCase : IGetHistoryTransactionsUseCase
    {
        private readonly IGetHistoryTransactionsQueries _getHistoryTransactionsQueries;

        public GetHistoryTransactionsUseCase(IGetHistoryTransactionsQueries getHistoryTransactionsQueries)
        {
            _getHistoryTransactionsQueries = getHistoryTransactionsQueries;
        }

        public async Task<ObjectResponse<List<GetHistoryTransactionsResponse>>> GetHistoryTransactions(GetHistoryTransactionsQuery history)
        {
            ObjectResponse<List<GetHistoryTransactionsResponse>> response = new ObjectResponse<List<GetHistoryTransactionsResponse>>();
            response.Code = 0;
            response.Msj = "Hubo un error al intentar obtener la información de las transacciones de la tarjeta de crédito";

            try
            {
                var request = await _getHistoryTransactionsQueries.GetHistoryTransactions(history);

                if (request != null)
                {
                    response.Code = 1;
                    response.Msj = "Éxito";
                    response.Item = request.ToList();
                }
                else
                {
                    response.Code = 1;
                    response.Msj = "No se encontraron transacciones correspondientes al mes";
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

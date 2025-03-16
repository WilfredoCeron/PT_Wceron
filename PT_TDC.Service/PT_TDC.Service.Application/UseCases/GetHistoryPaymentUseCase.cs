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
    public class GetHistoryPaymentUseCase : IGetHistoryPaymentUseCase
    {
        private readonly IGetHistoryPaymentQueries _historyPaymentQueries;

        public GetHistoryPaymentUseCase(IGetHistoryPaymentQueries gethistoryPaymentQueries)
        {
            _historyPaymentQueries = gethistoryPaymentQueries;
        }

        public async Task<ObjectResponse<List<GetHistoryPaymentResponse>>> GetHistoryPayment(GetHistoryPaymentQuery history)
        {
            ObjectResponse<List<GetHistoryPaymentResponse>> response = new ObjectResponse<List<GetHistoryPaymentResponse>>();
            response.Code = 0;
            response.Msj = "Hubo un error al intentar obtener la información de los pagos de la tarjeta de crédito";

            var request = await _historyPaymentQueries.GetHistoryPayment(history);

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
                    response.Code = 1;
                    response.Msj = "No existen pagos relacionos con el número de tarjeta de crédito y el mes ingresado";
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

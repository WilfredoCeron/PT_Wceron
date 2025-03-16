using PT_TDC.Service.Application.Features.CardInfo;
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
    public class GetInfoCardUseCase : IGetInfoCardUseCase
    {
        private readonly IGetInfoCardQueries _getInfoCardQueries;

        public GetInfoCardUseCase(IGetInfoCardQueries getInfoCardQueries)
        {
            _getInfoCardQueries = getInfoCardQueries;
        }

        public async Task<ObjectResponse<GetInfoCardResponse>> GetInfoCard(GetInfoCardQuery query)
        {
            ObjectResponse<GetInfoCardResponse> response = new ObjectResponse<GetInfoCardResponse>();

            response.Code = 0;
            response.Msj = "Hubo un error al intentar obtener información de la tarjeta de crédito " + query.CardNumber;

            try
            {
                var request = await _getInfoCardQueries.GetInfoCard(query.CardNumber);

                if (request != null)
                {
                    response.Code = 1;
                    response.Msj = "Éxito";
                    response.Item = request;
                }
                else
                {
                    response.Code = 1;
                    response.Msj = "No se encontraron registros relacionados a la tarjeta";
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

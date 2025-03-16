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
    public class GetParametersUseCase : IGetParametersUseCase
    {
        private readonly IParametersQueries _parametersQueries;

        public GetParametersUseCase(IParametersQueries parametersQueries)
        {
            _parametersQueries = parametersQueries;
        }

        public async Task<ObjectResponse<List<ParametersResponse>>> GetParameters()
        {
            ObjectResponse<List<ParametersResponse>> response = new ObjectResponse<List<ParametersResponse>>();
            
            try
            {
                var request = await _parametersQueries.GetParameters();

                if (request != null)
                {
                    response.Code = 1;
                    response.Msj = "Éxito";
                    response.Item = request.ToList();
                }
                else
                {
                    response.Code = 0;
                    response.Msj = "Hubo un error al intentar obtener los parámetros";
                }
            }
            catch (Exception e)
            {

               response.Msj = "Error: " + e.Message;
            }
           

            return response;
        }
    }
}

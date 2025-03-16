using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.Service.Application.Interfaces.Commands;
using PT_TDC.Service.Application.UseCases.Interfaces;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.UseCases
{
    public class CreateNewBuyUseCase : ICreateNewBuyUseCase
    {
        private readonly ICreateNewBuyCommand _createNewBuyCommand;

        public CreateNewBuyUseCase(ICreateNewBuyCommand createNewBuyCommand)
        {
            _createNewBuyCommand = createNewBuyCommand;
        }

        public async Task<GenericResponse> CreateNewBuy(CreateNewBuyQuery query)
        {
            GenericResponse response = new GenericResponse();

            try
            {
                var request = await _createNewBuyCommand.CreateNewBuy(query);
                if (request)
                {
                    response.Code = 1;
                    response.Msj = "Éxito";
                }
                else
                {
                    response.Code = 0;
                    response.Msj = "Hubo un error al intentar guardar la información de la compra realizada";
                }
            }
            catch (Exception e)
            {
                response.Msj += "Error: " + e.Message;
            }

            return response;
        }
    }
}

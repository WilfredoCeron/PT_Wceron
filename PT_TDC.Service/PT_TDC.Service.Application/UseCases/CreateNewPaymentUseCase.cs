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
    public class CreateNewPaymentUseCase : ICreateNewPaymentUseCase
    {
        private readonly ICreateNewPaymentCommand _createNewPaymentCommand;

        public CreateNewPaymentUseCase(ICreateNewPaymentCommand createNewPaymentCommand)
        {
            _createNewPaymentCommand = createNewPaymentCommand;
        }

        public async Task<GenericResponse> CreateNewPayment(CreateNewPaymentQuery query)
        {
            GenericResponse response = new GenericResponse();
            
            try
            {
                var request = await _createNewPaymentCommand.CreateNewPayment(query);
                if (request)
                {
                    response.Code = 1;
                    response.Msj = "Éxito";
                }
                else
                {
                    response.Code = 0;
                    response.Msj = "Hubo un error al intentar guardar la información del pago";
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

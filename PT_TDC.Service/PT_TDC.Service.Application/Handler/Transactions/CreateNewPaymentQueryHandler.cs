using MediatR;
using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.Service.Application.UseCases;
using PT_TDC.Service.Application.UseCases.Interfaces;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Handler.Transactions
{
    public class CreateNewPaymentQueryHandler : IRequestHandler<CreateNewPaymentQuery, GenericResponse>
    {
        private readonly ICreateNewPaymentUseCase _createNewPaymentUseCase;

        public CreateNewPaymentQueryHandler(ICreateNewPaymentUseCase createNewPaymentUseCase)
        {
            _createNewPaymentUseCase = createNewPaymentUseCase;
        }

        public async Task<GenericResponse> Handle(CreateNewPaymentQuery query, CancellationToken cancellationToken)
        {
            return await _createNewPaymentUseCase.CreateNewPayment(query);
        }
    }
}

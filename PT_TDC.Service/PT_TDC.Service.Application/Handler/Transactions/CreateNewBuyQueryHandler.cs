using MediatR;
using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.Service.Application.UseCases;
using PT_TDC.Service.Application.UseCases.Interfaces;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Handler.Transactions
{
    public class CreateNewBuyQueryHandler : IRequestHandler<CreateNewBuyQuery, GenericResponse>
    {

        private readonly ICreateNewBuyUseCase _createNewBuyUseCase;

        public CreateNewBuyQueryHandler(ICreateNewBuyUseCase createNuevaCompraUseCase)
        {
            _createNewBuyUseCase = createNuevaCompraUseCase;
        }

        public async Task<GenericResponse> Handle(CreateNewBuyQuery request, CancellationToken cancellationToken)
        {
            return await _createNewBuyUseCase.CreateNewBuy(request);
        }
    }
}

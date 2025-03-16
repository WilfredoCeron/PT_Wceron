using MediatR;
using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.Service.Application.UseCases.Interfaces;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Handler.Transactions
{
    public class GetHistoryBuyQueryHandler : IRequestHandler<GetHistoryBuyQuery, ObjectResponse<List<GetHistoryBuyResponse>>>
    {
        private readonly IGetHistoryBuyUseCase _getHistoryBuyUseCase;

        public GetHistoryBuyQueryHandler(IGetHistoryBuyUseCase getHistoryBuysUseCase)
        {
            _getHistoryBuyUseCase = getHistoryBuysUseCase;
        }

        public async Task<ObjectResponse<List<GetHistoryBuyResponse>>> Handle(GetHistoryBuyQuery query, CancellationToken cancellationToken)
        {
            return await _getHistoryBuyUseCase.GetHistoryBuy(query);
        }
    }
}

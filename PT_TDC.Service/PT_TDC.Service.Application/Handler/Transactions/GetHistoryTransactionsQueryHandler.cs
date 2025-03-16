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
    public class GetHistoryTransactionsQueryHandler : IRequestHandler<GetHistoryTransactionsQuery, ObjectResponse<List<GetHistoryTransactionsResponse>>>
    {
        private readonly IGetHistoryTransactionsUseCase _getHistoryTransactionsUseCase;

        public GetHistoryTransactionsQueryHandler(IGetHistoryTransactionsUseCase getHistoryTransactionsUseCase)
        {
            _getHistoryTransactionsUseCase = getHistoryTransactionsUseCase;
        }

        public async Task<ObjectResponse<List<GetHistoryTransactionsResponse>>> Handle(GetHistoryTransactionsQuery query, CancellationToken cancellationToken)
        {
            return await _getHistoryTransactionsUseCase.GetHistoryTransactions(query);
        }
    }
}

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
    public class GetHistoryPaymentQueryHandler : IRequestHandler<GetHistoryPaymentQuery, ObjectResponse<List<GetHistoryPaymentResponse>>>
    {
        private readonly IGetHistoryPaymentUseCase _getHistoryPaymentUseCase;

        public GetHistoryPaymentQueryHandler(IGetHistoryPaymentUseCase getHistoryPaymentsUseCase)
        {
            _getHistoryPaymentUseCase = getHistoryPaymentsUseCase;
        }

        public async Task<ObjectResponse<List<GetHistoryPaymentResponse>>> Handle(GetHistoryPaymentQuery query, CancellationToken cancellationToken)
        {
            return await _getHistoryPaymentUseCase.GetHistoryPayment(query);
        }
    }
}

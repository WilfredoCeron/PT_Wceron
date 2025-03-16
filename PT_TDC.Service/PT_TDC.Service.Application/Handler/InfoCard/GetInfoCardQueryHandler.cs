using MediatR;
using PT_TDC.Service.Application.Features.CardInfo;
using PT_TDC.Service.Application.UseCases.Interfaces;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Handler.InfoCard
{
    public class GetInfoCardQueryHandler : IRequestHandler<GetInfoCardQuery, ObjectResponse<GetInfoCardResponse>>
    {
        private readonly IGetInfoCardUseCase _getInfoCardUseCase;
        public GetInfoCardQueryHandler(IGetInfoCardUseCase getInfoCardUseCase)
        {
            _getInfoCardUseCase = getInfoCardUseCase;
        }

        public async Task<ObjectResponse<GetInfoCardResponse>> Handle(GetInfoCardQuery request, CancellationToken cancellationToken)
        {
            return await _getInfoCardUseCase.GetInfoCard(request);
        }
    }
}

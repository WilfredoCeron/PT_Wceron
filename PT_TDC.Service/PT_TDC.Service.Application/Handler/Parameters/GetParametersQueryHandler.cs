using MediatR;
using PT_TDC.Service.Application.Features.Parameters;
using PT_TDC.Service.Application.UseCases.Interfaces;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Handler.Parameters
{
    public class GetParametersQueryHandler : IRequestHandler<GetParametersQuery, ObjectResponse<List<ParametersResponse>>>
    {
        private readonly IGetParametersUseCase _getParametersUseCase;

        public GetParametersQueryHandler(IGetParametersUseCase getParametersUseCase)
        {
            _getParametersUseCase = getParametersUseCase;
        }

        public async Task<ObjectResponse<List<ParametersResponse>>> Handle(GetParametersQuery query, CancellationToken cancellationToken)
        {
            return await _getParametersUseCase.GetParameters();
        }
    }
}

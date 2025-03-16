using MediatR;
using PT_TDC.SERVICE.Domain.Entities;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Features.Parameters
{
    public class GetParametersQuery :IRequest<ObjectResponse<List<ParametersResponse>>>
    {
    }
}

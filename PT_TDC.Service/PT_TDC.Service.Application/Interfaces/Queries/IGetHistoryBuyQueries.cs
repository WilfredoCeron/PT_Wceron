using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.SERVICE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Interfaces.Queries
{
    public interface IGetHistoryBuyQueries
    {
        Task<List<GetHistoryBuyResponse>> GetHistoryBuy(GetHistoryBuyQuery history);
    }
}

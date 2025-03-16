using Dapper;
using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.Service.Application.Interfaces.Queries;
using PT_TDC.Service.Infrastructure.DBContext.Interface;
using PT_TDC.SERVICE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Infrastructure.Queries
{
    internal class GetHistoryBuyQueries : IGetHistoryBuyQueries
    {
        private readonly ISqlServerDBContext _dbContext;

        public GetHistoryBuyQueries(ISqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetHistoryBuyResponse>> GetHistoryBuy(GetHistoryBuyQuery history)
        {
            var querySelect = "sp_GetHistoryBuy @CardNumber, @Month, @Year";
            var connection = _dbContext.GetConnectionSlqServer();
            var result = await connection.QueryAsync<GetHistoryBuyResponse>(querySelect, history);
            return result.ToList();
        }
    }
}

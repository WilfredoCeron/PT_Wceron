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
    public class GetHistoryTransactionsQueries : IGetHistoryTransactionsQueries
    {
        private readonly ISqlServerDBContext _dbContext;

        public GetHistoryTransactionsQueries(ISqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetHistoryTransactionsResponse>> GetHistoryTransactions(GetHistoryTransactionsQuery history)
        {
            var querySelect = "sp_GetHistoryCard @CardNumber, @Month, @Year";
            var connection = _dbContext.GetConnectionSlqServer();

            var result = await connection.QueryAsync<GetHistoryTransactionsResponse>(querySelect, history);
            return result.ToList();
        }
    }
}

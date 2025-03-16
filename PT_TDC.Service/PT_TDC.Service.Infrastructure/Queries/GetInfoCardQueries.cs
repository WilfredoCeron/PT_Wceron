using Dapper;
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
    public class GetInfoCardQueries : IGetInfoCardQueries
    {
        private readonly ISqlServerDBContext _dbContext;

        public GetInfoCardQueries(ISqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetInfoCardResponse> GetInfoCard(string CardNumber)
        {
            var querySelect = "EXEC sp_GetDataCard @CardNumber";

            using var connection = _dbContext.GetConnectionSlqServer();
            var result = await connection.QueryAsync<GetInfoCardResponse>(querySelect, new { CardNumber } );

            return result.FirstOrDefault();
        }
    }
}

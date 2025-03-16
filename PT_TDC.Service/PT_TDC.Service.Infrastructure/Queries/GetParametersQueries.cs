using PT_TDC.Service.Infrastructure.DBContext.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT_TDC.Service.Application.Interfaces.Queries;
using Dapper;
using PT_TDC.SERVICE.Domain.Entities;

namespace PT_TDC.Service.Infrastructure.Queries
{
    public class GetParametersQueries : IParametersQueries
    {
        private readonly ISqlServerDBContext _dbContext;

        public GetParametersQueries(ISqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<ParametersResponse>> GetParameters()
        {
            var querySelect = "Select * from Parameters";

            using var connection = _dbContext.GetConnectionSlqServer();
            var result = await connection.QueryAsync<ParametersResponse>(querySelect);
            return result.ToList();
        }
    }
}

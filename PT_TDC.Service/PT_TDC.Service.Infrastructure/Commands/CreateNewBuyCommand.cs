using Dapper;
using PT_TDC.Service.Application.Features.Transactions;
using PT_TDC.Service.Application.Interfaces.Commands;
using PT_TDC.Service.Infrastructure.DBContext.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Infrastructure.Commands
{
    public class CreateNewBuyCommand : ICreateNewBuyCommand
    {
        private readonly ISqlServerDBContext _dbContext;

        public CreateNewBuyCommand(ISqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateNewBuy(CreateNewBuyQuery query)
        {
            try
            {
                var command = "sp_CreateBuy @CardNumber, @DateBuy, @DescriptionT, @Amount";
                using var connection = _dbContext.GetConnectionSlqServer();
                var paraments = new
                {
                    CardNumber = query.CardNumber,
                    DateBuy = query.DateBuy,
                    DescriptionT = query.Description,
                    Amount = query.Amount
                };
                var result = await connection.ExecuteAsync(command, paraments);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

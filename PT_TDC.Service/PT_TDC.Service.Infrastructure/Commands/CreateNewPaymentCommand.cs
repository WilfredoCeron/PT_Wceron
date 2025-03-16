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
    public class CreateNewPaymentCommand : ICreateNewPaymentCommand
    {
        private readonly ISqlServerDBContext _dbContext;

        public CreateNewPaymentCommand(ISqlServerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateNewPayment(CreateNewPaymentQuery query)
        {
            try
            {
                var command = "sp_CreatePayment @CardNumber, @DatePayment, @DescriptionT, @Amount";
                using var connection = _dbContext.GetConnectionSlqServer();
                var paraments = new
                {
                    CardNumber = query.CardNumber,
                    DatePayment = query.DatePayment,
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

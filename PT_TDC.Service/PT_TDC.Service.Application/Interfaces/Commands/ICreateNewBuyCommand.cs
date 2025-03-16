using PT_TDC.Service.Application.Features.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Interfaces.Commands
{
    public interface ICreateNewBuyCommand
    {
        Task<bool> CreateNewBuy(CreateNewBuyQuery query);
    }
}

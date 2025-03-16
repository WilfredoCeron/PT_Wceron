﻿using MediatR;
using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Application.Features.Transactions
{
    public class CreateNewPaymentQuery : Transaction
    {
        public DateTime DatePayment { get; set; }
    }
}

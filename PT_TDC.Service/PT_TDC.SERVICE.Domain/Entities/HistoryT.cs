 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.SERVICE.Domain.Entities
{
    public class HistoryT
    {
        public int IdTransactions { get; set; }
        public string CardNumber { get; set; }
        public int MonthT { get; set; }
        public int YearT { get; set;}
        public string DescriptionT { get; set; }
        public decimal Amount { get; set; }
        public string TransactionsType { get; set; }
        public DateTime DateTransactions { get; set; }
    }
}

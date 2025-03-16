using PT_TDC.SERVICE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.SERVICE.Domain.Entities
{
    public class GetInfoCardResponse
    {
        public string CardNumber { get; set; }
        public string AssociatedName { get; set; }
        public decimal SaldoActual { get; set; }
        public decimal SaldoDisponible { get; set; }
        public string  DateExpiration { get; set; }
        public int Cvv { get; set; }
        public decimal Limit { get; set; }
        public DateTime FechadeCorte { get; set; }
        public decimal CuotaMinimaPagar { get; set; }
        public decimal MontoTotalContado { get; set; }
        public decimal InteresConfigurableMinimo { get; set; }
        public decimal InteresConfigurable { get; set; }
        public decimal InteresBonificable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.SERVICE.Domain.Entities
{
    public class ParametersResponse
    {
        public int IdParameters { get; set; }
        public string NameParameters { get; set; }
        public string ValueParameters { get; set; }
        public string TypeParameters { get; set; }
    }
}

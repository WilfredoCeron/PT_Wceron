using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.SERVICE.Domain.Entities.Base
{
    public class ListResponse<T> : GenericResponse
    {
        public List<T> Items { get; set; }
    }
}

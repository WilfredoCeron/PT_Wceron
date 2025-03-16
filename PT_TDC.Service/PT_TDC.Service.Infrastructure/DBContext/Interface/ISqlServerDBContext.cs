using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Infrastructure.DBContext.Interface
{
    public interface ISqlServerDBContext
    {
        IDbConnection GetConnectionSlqServer();
    }
}

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PT_TDC.Service.Infrastructure.DBContext.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT_TDC.Service.Infrastructure.DBContext
{
    public class SqlServerDBContext : ISqlServerDBContext
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _connection;

        public SqlServerDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection GetConnectionSlqServer()
        {
            var connection = _configuration.GetConnectionString("SqlServerConnection");
            _connection = new SqlConnection(connection);

            return _connection;
        }
    }
}

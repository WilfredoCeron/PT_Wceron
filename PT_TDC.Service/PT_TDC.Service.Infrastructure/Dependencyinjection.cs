
using PT_TDC.Service.Infrastructure.DBContext.Interface;
using PT_TDC.Service.Infrastructure.DBContext;
using PT_TDC.Service.Application.Interfaces.Queries;
using PT_TDC.Service.Application.Interfaces.Commands;
using PT_TDC.Service.Infrastructure.Commands;
using PT_TDC.Service.Infrastructure.Queries;
using Microsoft.Extensions.DependencyInjection;
namespace PT_TDC.Service.Infrastructure
{
    public static class Dependencyinjection
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ISqlServerDBContext, SqlServerDBContext>();
            services.AddTransient<IParametersQueries, GetParametersQueries>();
            services.AddTransient<IGetInfoCardQueries, GetInfoCardQueries>();
            services.AddTransient<IGetHistoryTransactionsQueries, GetHistoryTransactionsQueries>();
            services.AddTransient<IGetHistoryBuyQueries, GetHistoryBuyQueries>();
            services.AddTransient<IGetHistoryPaymentQueries, GetHistoryPaymentQueries>();
            services.AddTransient<ICreateNewBuyCommand, CreateNewBuyCommand>();
            services.AddTransient<ICreateNewPaymentCommand, CreateNewPaymentCommand>();
        }
    }
}

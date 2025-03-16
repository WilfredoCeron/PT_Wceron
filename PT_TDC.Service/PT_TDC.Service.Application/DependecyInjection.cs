using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using PT_TDC.Service.Application.UseCases;
using PT_TDC.Service.Application.UseCases.Interfaces;

namespace PT_TDC.Service.Application
{
    public static class DependecyInjection
    {
        public static void AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient<IGetParametersUseCase, GetParametersUseCase>();
            services.AddTransient<IGetInfoCardUseCase, GetInfoCardUseCase>();
            services.AddTransient<IGetHistoryTransactionsUseCase, GetHistoryTransactionsUseCase>();
            services.AddTransient<IGetHistoryBuyUseCase, GetHistoryBuyUseCase>();
            services.AddTransient<IGetHistoryPaymentUseCase, GetHistoryPaymentUseCase>();
            services.AddTransient<ICreateNewBuyUseCase, CreateNewBuyUseCase>();
            services.AddTransient<ICreateNewPaymentUseCase, CreateNewPaymentUseCase>();
        }
    }
}

using Exam.BusinessLogic.Interfaces;
using Exam.BusinessLogic.Services;
using Exam.DataAccess.Interfaces;
using Exam.DataAccess.Services;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Exam_TrackingAPI.Extensions
{
    public static class BusinessLogicExtensions
    {
        public static IServiceCollection AddBusinessLogic(
            this IServiceCollection services)
        {
            services.AddTransient<ISortingDupInputService, SortingDupInputServiceBLL>();
            services.AddTransient<IUsePublicApiService, UsePublicApiServiceBLL>();
            services.AddTransient<IInMemoryDataService, InMemoryDataServiceBLL>();
            services.AddTransient<IInMemoryDataServiceDAL, InMemoryDataServiceDAL>();
            return services;
        }

        
    }
}

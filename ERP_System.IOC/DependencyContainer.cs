
using ERP_System.BLL;
using ERP_System.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ERP_System.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region DAL

            services.AddScoped(typeof(IUnitOfWork<ERP_SystemDbContext>), typeof(UnitOfWork<ERP_SystemDbContext>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
            var BllClasses = typeof(PageBll).Assembly.GetTypes().Where(p => p.IsClass && p.Name.ToLower().Contains("bll"));

            #region BLL
            BllClasses.ToList().ForEach(p =>
            {
                services.AddScoped(p);

            });
            //services.AddScoped<UserBll>();
            //services.AddScoped<SendBll>();
            //services.AddScoped<GasStationBll>();
            //services.AddScoped<VisitBll>();
            //services.AddScoped<QuestionsBll>();
            //services.AddScoped<CityBll>();
            //services.AddScoped<ManualDistributionBll>();
            //services.AddScoped<DashboardBll>();
            #endregion

        }
    }
}

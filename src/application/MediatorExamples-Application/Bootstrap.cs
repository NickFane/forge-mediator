
using MediatorExamples_Db;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorExamples_Application
{
    public static class Bootstrap
    {
        public static void BootstrapApplication(IServiceCollection services)
        {
            DbBootstrap.BootstrapDb(services);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Bootstrap).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(DbBootstrap).Assembly);
            });

        }
    }
}

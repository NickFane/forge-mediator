

using MediatorExamples_Db.Contexts;
using MediatorExamples_Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorExamples_Db
{
    public static class DbBootstrap
    {
        public static void BootstrapDb(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            services.AddDbContext<BreedContext>(options => options.UseRootApplicationServiceProvider()); 
            services.AddTransient<IBreedRepository, BreedRepository>();
        }
    }
}

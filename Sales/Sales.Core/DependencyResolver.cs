using Microsoft.Extensions.DependencyInjection;
using Sales.Business.Interfaces;
using Sales.Business.Services;
using Sales.Data.Interfaces;
using Sales.Data.Repositories;

namespace Sales.Core
{
    public class DependencyResolver
    {
        const string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Sales;Integrated Security=SSPI;";
        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>(provider => new UserRepository(ConnectionString));
            services.AddTransient<IUserService, UserService>();
        }
    }
}
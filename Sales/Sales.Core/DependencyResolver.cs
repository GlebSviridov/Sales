using Microsoft.Extensions.DependencyInjection;
using Sales.BusinessLayer.Interfaces;
using Sales.BusinessLayer.Services;
using Sales.DataLayer.Interfaces;
using Sales.DataLayer.Repositories;

namespace Sales.Core
{
    public class DependencyResolver
    {
        const string ConnectionString =
            @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=Sales;Integrated Security=SSPI;";

        public static void InjectDependencies(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>(provider => new UserRepository(ConnectionString));
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IBookRepository, BookRepository>(provider => new BookRepository(ConnectionString));
            services.AddTransient<IBookService, BookService>();

            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>(provider =>
                new ShoppingCartRepository(ConnectionString));
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
        }
    }
}
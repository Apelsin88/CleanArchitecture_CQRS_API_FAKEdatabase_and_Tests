using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.RepositoryInterfaces;
using Infrastructure.Database;
using Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            //services.AddSingleton<FakeDatabase>();

            services.AddDbContext<RealDatabase>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}

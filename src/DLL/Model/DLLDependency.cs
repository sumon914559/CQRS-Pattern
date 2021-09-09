using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL.Model.UoW;
using DLL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL.Model
{
    public static class DLLDependency
    {
        public static void AllDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MvcMovieContext")));


            services.AddDbContext<SecondaryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MvcMovieContext123")));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
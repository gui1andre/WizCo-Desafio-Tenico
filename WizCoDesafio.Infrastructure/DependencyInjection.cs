using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WizCoDesafio.Domain.Interfaces;
using WizCoDesafio.Infrastructure.Data;
using WizCoDesafio.Infrastructure.Repositories;

namespace WizCoDesafio.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(op => op.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPedidoRepository, PedidoRepository>();

            return services;
        }
    }
}

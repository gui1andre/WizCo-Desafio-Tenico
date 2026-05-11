using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WizCoDesafio.Application.Mappings;
using WizCoDesafio.Application.Pedido.Interfaces;
using WizCoDesafio.Application.Pedidos;
using WizCoDesafio.Application.Validators;

namespace WizCoDesafio.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<PedidoDTOValidator>();

            services.AddAutoMapper(c => c.AddProfile<PedidoMappingProfile>(), typeof(DependencyInjection));

            services.AddScoped<IPedidoService, PedidoService>();

            return services;
        }
    }
}

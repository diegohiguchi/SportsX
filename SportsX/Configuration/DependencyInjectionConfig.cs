using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SportsX.Application.Clientes;
using SportsX.Application.PessoasFisicas;
using SportsX.Application.PessoasJuridicas;
using SportsX.Domain.Interfaces;
using SportsX.Domain.Interfaces.Repositories;
using SportsX.Domain.Interfaces.Services;
using SportsX.Domain.Notificacoes;
using SportsX.Domain.Services;
using SportsX.IApplication.Clientes;
using SportsX.IApplication.PessoasFisicas;
using SportsX.IApplication.PessoasJuridicas;
using SportsX.Infra.Context;
using SportsX.Infra.Repository;

namespace SportsX.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
            services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IPessoaFisicaService, PessoaFisicaService>();
            services.AddScoped<IPessoaJuridicaService, PessoaJuridicaService>();
            services.AddScoped<ITelefoneService, TelefoneService>();

            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IPessoaFisicaApplication, PessoaFisicaApplication>();
            services.AddScoped<IPessoaJuridicaApplication, PessoaJuridicaApplication>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}

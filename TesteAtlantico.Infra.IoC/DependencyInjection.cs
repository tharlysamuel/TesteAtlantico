using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TesteAtlantico.Domain.Interfaces.Repository;
using TesteAtlantico.Domain.Interfaces.Services;
using TesteAtlantico.Infra.Data.Repository;
using TesteAtlantico.Service;

namespace TesteAtlantico.Infra.IoC
{
    public class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}

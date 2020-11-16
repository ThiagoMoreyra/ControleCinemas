using ControleCinemas.Business.Interfaces;
using ControleCinemas.Business.Services;
using ControleCinemas.Data.Context;
using ControleCinemas.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ControleCinemas.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<CinemaDbContext>();
            services.AddScoped<IAtorRepository, AtorRepository>();
            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<ISessaoRepository, SessaoRepository>();
            services.AddScoped<ICinemaRepository, CinemaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IIngressoRepository, IngressoRepository>();

            services.AddScoped<IAtorService, AtorService>();
            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<ISessaoService, SessaoService>();
            services.AddScoped<ICinemaService, CinemaService>();
            services.AddScoped<IEnderecoService, EnderecoService>();
            services.AddScoped<IIngressoService, IngressoService>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
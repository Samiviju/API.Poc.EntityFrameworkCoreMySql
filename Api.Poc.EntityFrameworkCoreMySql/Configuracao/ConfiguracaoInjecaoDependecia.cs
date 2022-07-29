using Api.Poc.EntityFrameworkCoreMySql.Dominio.Interfaces;
using Api.Poc.EntityFrameworkCoreMySql.Infra.Repositorios;
using Api.Poc.EntityFrameworkCoreMySql.Servico;

namespace Api.Poc.EntityFrameworkCoreMySql.Configuracao
{
    public static class ConfiguracaoInjecaoDependecia
    {
        public static IServiceCollection ResolverDependencias(this IServiceCollection services)
        {
            services.AddScoped<IServicoLog, ServicoLog>();
            services.AddScoped<IRepositorioOrquestrador, RepositorioOrquestrador>();
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();

            return services;
        }
    }
}
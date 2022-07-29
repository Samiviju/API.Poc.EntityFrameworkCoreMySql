using Api.Poc.EntityFrameworkCoreMySql.Dominio.Interfaces;

namespace Api.Poc.EntityFrameworkCoreMySql.Infra.Repositorios
{
    public class RepositorioOrquestrador : IRepositorioOrquestrador
    {
        public IRepositorioCliente Cliente
        {
            get { return new RepositorioCliente(); }
        }
    }
}
using Api.Poc.EntityFrameworkCoreMySql.Dominio.Entidades;

namespace Api.Poc.EntityFrameworkCoreMySql.Dominio.Interfaces
{
    public interface IRepositorioCliente
    {
        Task<Clientes?> ObterClientePorIdAsync(Guid id);

        Task<List<Clientes>?> ObterTodosClientesAsync();

        Task<Guid?> AdicionarNovoClienteAsync(Clientes cliente);

        Task<bool> AtualizarClienteAsync(Clientes cliente);

        Task<bool> DeletarCliente(Clientes cliente);
    }
}
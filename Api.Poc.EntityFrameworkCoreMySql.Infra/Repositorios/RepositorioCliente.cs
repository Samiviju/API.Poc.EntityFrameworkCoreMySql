using Api.Poc.EntityFrameworkCoreMySql.Dominio.Entidades;
using Api.Poc.EntityFrameworkCoreMySql.Dominio.Interfaces;
using Api.Poc.EntityFrameworkCoreMySql.Infra.Contextos;

namespace Api.Poc.EntityFrameworkCoreMySql.Infra.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private DbContextoRepositorios ContextoCliente { get; }

        public RepositorioCliente()
        {
            ContextoCliente = new DbContextoRepositorios();
        }

        public async Task<Clientes?> ObterClientePorIdAsync(Guid id) => ContextoCliente.Set<Clientes>().Where(c => c.Id == id).FirstOrDefault();

        public async Task<List<Clientes>?> ObterTodosClientesAsync() => ContextoCliente.Clientes.ToList();

        public async Task<Guid?> AdicionarNovoClienteAsync(Clientes cliente)
        {
            await ContextoCliente.Clientes.AddAsync(cliente);
            ContextoCliente.SaveChanges();

            return cliente.Id;
        }

        public async Task<bool> AtualizarClienteAsync(Clientes cliente)
        {
            var clienteExistente = await ObterClientePorIdAsync(cliente.Id);

            if (clienteExistente == null)
                return false;

            clienteExistente.Id = cliente.Id;
            clienteExistente.Cpf = cliente.Cpf;
            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Sobrenome = cliente.Sobrenome;
            clienteExistente.Nascimento = cliente.Nascimento;

            ContextoCliente.Clientes.Update(clienteExistente);
            ContextoCliente.SaveChanges();

            return true;
        }

        public async Task<bool> DeletarCliente(Clientes cliente)
        {
            var clienteExistente = await ObterClientePorIdAsync(cliente.Id);

            if (clienteExistente == null)
                return false;

            ContextoCliente.Clientes.Remove(clienteExistente);

            return true;
        }
    }
}
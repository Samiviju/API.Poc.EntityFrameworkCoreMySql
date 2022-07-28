namespace Api.Poc.EntityFrameworkCoreMySql.Dominio.Interfaces
{
    public interface IServicoLog
    {
        Task GravarLogAsync(object log, Guid identificador);
    }
}
using Api.Poc.EntityFrameworkCoreMySql.Infra.Integracoes;

namespace Api.Poc.EntityFrameworkCoreMySql.Servico
{
    public class ServicoLog
    {
        private readonly IntegracoesWebApiLogs _integracaoWebApiLogs;

        public ServicoLog()
        {
            _integracaoWebApiLogs = new IntegracoesWebApiLogs();
        }

        public async Task GravarLogAsync(object log, Guid identificador)
        {
            await _integracaoWebApiLogs.GravarLogAsync(log, identificador);
        }
    }
}
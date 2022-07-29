using Api.Poc.EntityFrameworkCoreMySql.Utilitario;
using Lib.Comum.LogAplicacao;
using Newtonsoft.Json;

namespace Api.Poc.EntityFrameworkCoreMySql.Infra.Integracoes
{
    public class IntegracoesWebApiLogs
    {
        public async Task GravarLogAsync(object log, Guid identificador)
        {
            Log modeloLog = new();
            modeloLog.IdentificadorAplicacao = "Api.Poc.EntityFrameworkCoreMySql";
            modeloLog.TipoLog = EnumTipoLog.Erro;
            modeloLog.NomeComponente = "Api.Poc.EntityFrameworkcoreMySql";
            modeloLog.Descricao = JsonConvert.SerializeObject(log);
            modeloLog.DataHoraInclusao = DateTime.Now;

            ClienteLog clienteLog = new(ConfiguracoesDaAplicacao.ObterRegiaoAws());
            await clienteLog.GravarLogAsync(modeloLog);
        }
    }
}
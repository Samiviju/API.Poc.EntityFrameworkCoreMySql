namespace Api.Poc.EntityFrameworkCoreMySql.Utilitario
{
    public static class ConfiguracoesDaAplicacao
    {
        public static string ObterRegiaoAws()
        {
            Configuracao configuracao = new();
            var regiaoAws = configuracao.ConfiguracaoDoArquivoAppSettings["AwsRegion"];

            if (string.IsNullOrEmpty(regiaoAws))
                throw new ArgumentException("Erro ao carregar a chave de configuração AwsRegion.");

            return regiaoAws;
        }

        public static string ObterChaveCofreDeSenha()
        {
            Configuracao configuracao = new();
            var chaveCofreSenha = configuracao.ConfiguracaoDoArquivoAppSettings["ChaveCofreDeSenhas"];

            if (string.IsNullOrEmpty(chaveCofreSenha))
                throw new ArgumentException("Erro ao carregar a chave de configuração ChaveCofreDeSenhas.");

            return chaveCofreSenha;
        }
    }
}
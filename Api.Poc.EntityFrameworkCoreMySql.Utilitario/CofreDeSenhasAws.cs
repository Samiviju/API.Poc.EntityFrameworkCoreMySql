using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Text.Json.Nodes;

namespace Api.Poc.EntityFrameworkCoreMySql.Utilitario
{
    public class CofreDeSenhasAws
    {
        public string ConnectionString { get; set; }

        public CofreDeSenhasAws()
        {
            string chaveCofreDeSenha = ConfiguracoesDaAplicacao.ObterChaveCofreDeSenha();
            string segredoRetornado = string.Empty;

            IAmazonSecretsManager amazonSecretsManagerClient = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(ConfiguracoesDaAplicacao.ObterRegiaoAws()));

            GetSecretValueRequest secretValueRequest = new GetSecretValueRequest();
            secretValueRequest.SecretId = chaveCofreDeSenha;
            secretValueRequest.VersionStage = "AWSCURRENT";

            GetSecretValueResponse response = null;

            response = amazonSecretsManagerClient.GetSecretValueAsync(secretValueRequest).Result;

            if (response.SecretString != null)
            {
                segredoRetornado = response.SecretString;
            }

            JsonObject segredoRecuperado = JsonNode.Parse(segredoRetornado).AsObject();
            ConnectionString = segredoRecuperado["ConnectionString"].ToString();
        }
    }
}
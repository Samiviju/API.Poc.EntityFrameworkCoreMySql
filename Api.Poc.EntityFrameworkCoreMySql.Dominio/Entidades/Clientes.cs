namespace Api.Poc.EntityFrameworkCoreMySql.Dominio.Entidades
{
    public class Clientes
    {
        [Key]
        public Guid Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
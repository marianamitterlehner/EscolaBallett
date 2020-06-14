
namespace ProjetoModeloDDD.Domain.Entities
{
   public class Contato : EntityBase
    {
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Mensagem { get; set; }
    }
}

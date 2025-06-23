namespace JusFacil.API.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }

        
        public List <Cliente> Clientes { get; set; }
        public List <Processo> Processos { get; set; }
        public List <Atendimento> Atendimentos { get; set; }

    }
}

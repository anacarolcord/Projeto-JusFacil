namespace JusFacil.API.Models
{
    public class Cliente
    {   
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public int UsuarioId { get; set; }
        public string? Observacao { get; set; }

        public Usuario Usuario { get; set; }
        public List <Processo> Processos { get; set; }
    }
}

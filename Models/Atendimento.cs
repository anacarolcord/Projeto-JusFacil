namespace JusFacil.API.Models
{
    public class Atendimento
    {
        public int AtendimentoId { get; set; }
        public  int ClienteId { get; set; }
        public DateTime Data {  get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public List<Documento> Documentos { get; set; }
        public Processo? Processo { get; set; }

        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
    }
}

namespace JusFacil.API.Models
{
    public class Processo
    {
        public int ProcessoId { get; set; }
        public int ClienteId { get; set; }
        public string NumeroProcesso { get; set; }
        public string Descricao { get; set; }
        public string Status {  get; set; }
        public DateTime CriadoEm {  get; set; }
        public int UsuarioId { get; set; }

        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public List<Documento> Documentos { get; set; } = new List<Documento>();


        
    }
}

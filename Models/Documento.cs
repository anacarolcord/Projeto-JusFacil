namespace JusFacil.API.Models
{
    public class Documento
    {
        public int DocumentoId { get; set; }
        public Atendimento Atendimento { get; set; }
        public string NomeArquivo { get; set; }
        public string CaminhoArquivo { get; set; }
        public string TipoArquivo { get; set; }
        public DateTime DataUpload {  get; set; }

        

    }
}

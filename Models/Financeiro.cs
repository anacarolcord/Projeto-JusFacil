using Microsoft.AspNetCore.Routing.Constraints;

namespace JusFacil.API.Models
{
    public class Financeiro
    {
        public int FinanceiroId { get; set; }
        public int ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataPagamento { get; set; }
        public string FormaPagamento { get; set; }
        public string StatusPagamento { get; set; }
        public int ProcessoId { get; set; }
        public int UsuarioId { get; set; }



        public Processo Processo { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }    

    }
}

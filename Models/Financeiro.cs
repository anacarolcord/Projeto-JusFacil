using Microsoft.AspNetCore.Routing.Constraints;
using System.Security.Cryptography.X509Certificates;

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




        public Boolean EstaQuitado()
        {
            if (ValorPago >= ValorTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public string AtualizarStatus()
        {
            if (ValorPago != 0 && ValorPago < ValorTotal)
            {
                StatusPagamento = "Parcialmente pago";

            }else if (ValorPago == 0)
            {
                StatusPagamento = "Pagamento Pendente"; 
                
            }else if (ValorPago >= ValorTotal)
            {
                StatusPagamento = "Pagamento Quitado";
            }

            return StatusPagamento;
        }


       
        public void RegistrarPagamento(decimal valor, DateTime data, string formaPag)
        {
            ValorPago += valor;
            DataPagamento = data;
            FormaPagamento = formaPag;
            AtualizarStatus();
            
        }

        public void DefinirValorTotal(decimal valorTotal)
        {
            ValorTotal = valorTotal;
        }

        public decimal CalcularSaldoPendente()
        {
            decimal valorPendente = ValorTotal - ValorPago;
            if (valorPendente < 0)
            {
                return 0;
            }

            return valorPendente;
            

        }
    }
}

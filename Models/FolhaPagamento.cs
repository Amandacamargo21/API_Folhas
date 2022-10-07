using System;

namespace API_Folhas.Models
{
    public class FolhaPagamento
    {
        //Data Annotations
        public FolhaPagamento() => CriadoEm = DateTime.Now;

        public int FolhaPagamentoId { get; set; }
        public double ValorHora { get; set; }
        public double QuantidadeDeHoras { get; set; }
        public double SalarioBruto { get; set; }
        public double ImpostoRenda { get; set; }
        public double Inss { get; set; }
        public double Fgts { get; set; }
        public double SalarioLiquido { get; set; }
        public int Data { get; set; }
        public DateTime CriadoEm { get; set; }


        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Destinoreparc {
        [Key]
        public string Numprocesso { get; set; }
        public int Anoproc { get; set; }
        public int Numproc { get; set; }
        public int Codreduzido { get; set; }
        public short Anoexercicio { get; set; }
        public short Codlancamento { get; set; }
        public byte Numsequencia { get; set; }
        public byte Numparcela { get; set; }
        public byte Codcomplemento { get; set; }
        public decimal? Valorliquido { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Correcao { get; set; }
        public decimal?  Valorprincipal { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? Jurosperc { get; set; }
        public decimal? Jurosvalor { get; set; }
        public decimal? Jurosapl { get; set; }
        public decimal? Honorario { get; set; }
        public decimal? Total { get; set; }
        public decimal? Penalidade { get; set; }
        public decimal? Valorparcela { get; set; }
    }

    public class DestinoreparcStruct {
        [Key]
        public string Numero_Processo_Unificado { get; set; }
        public int Ano_Processo { get; set; }
        public int Numero_Processo { get; set; }
        public int Codigo { get; set; }
        public short Exercicio { get; set; }
        public short Lancamento_Codigo { get; set; }
        public byte Sequencia { get; set; }
        public byte Parcela { get; set; }
        public byte Complemento { get; set; }
        public decimal? Valor_Liquido { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Correcao { get; set; }
        public decimal? Valor_Principal { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? Juros_Percentual { get; set; }
        public decimal? Juros_Valor { get; set; }
        public decimal? Juros_Aplicado { get; set; }
        public decimal? Honorario { get; set; }
        public decimal? Total { get; set; }
        public decimal? Penalidade { get; set; }
        public decimal? Valor_Parcela { get; set; }
        public DateTime Data_Vencimento { get; set; }
        public short Situacao_Lancamento_Codigo { get; set; }
        public string Situacao_Lancamento_Descricao { get; set; }
    }

}

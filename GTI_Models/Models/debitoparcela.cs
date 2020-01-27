using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Debitoparcela {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Anoexercicio { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codlancamento { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Seqlancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public byte Numparcela { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Codcomplemento { get; set; }
        public byte Statuslanc { get; set; }
        public DateTime Datavencimento { get; set; }
        public DateTime Datadebase { get; set; }
        public short? Codmoeda { get; set; }
        public int? Numerolivro { get; set; }
        public int? Paginalivro { get; set; }
        public int? Numcertidao { get; set; }
        public DateTime? Datainscricao { get; set; }
        public DateTime? Dataajuiza { get; set; }
        public decimal? Valorjuros { get; set; }
        public string Numprocesso { get; set; }
        public bool? Intacto { get; set; }
        public bool? Notificado { get; set; }
        public int? Numexecfiscal { get; set; }
        public short? Anoexecfiscal { get; set; }
        public string Processocnj { get; set; }
        public bool? Simplesnacional { get; set; }
        public int? Protesto_nro_titulo { get; set; }
        public short? Protesto_data_remessa { get; set; }
        public int? Userid { get; set; }
    }

    public class DebitoStructure {
        public string Usuario { get; set; }
        public int Codigo_Reduzido { get; set; }
        public int Ano_Exercicio { get; set; }
        public int Codigo_Lancamento { get; set; }
        public string Descricao_Lancamento { get; set; }
        public int Sequencia_Lancamento { get; set; }
        public short? Numero_Parcela { get; set; }
        public short Complemento { get; set; }
        public DateTime? Data_Vencimento { get; set; }
        public DateTime Data_Base { get; set; }
        public int MyProperty { get; set; }
        public int Codigo_Situacao { get; set; }
        public string Nome_Situacao { get; set; }
        public string Numero_Processo { get; set; }
        public int Codigo_Tributo { get; set; }
        public string Descricao_Tributo { get; set; }
        public string Abreviatura_Tributo { get; set; }
        public Decimal Soma_Principal { get; set; }
        public Decimal Soma_Multa { get; set; }
        public Decimal Soma_Juros { get; set; }
        public Decimal Soma_Correcao { get; set; }
        public Decimal Soma_Total { get; set; }
        public DateTime? Data_Inscricao { get; set; }
        public DateTime? Data_Ajuizamento { get; set; }
        public int? Numero_Livro { get; set; }
        public int? Pagina_Livro { get; set; }
        public int? Numero_Certidao { get; set; }
        public bool Notificado { get; set; }
        public DateTime? Data_Pagamento { get; set; }
        public double Numero_Documento { get; set; }
        public Decimal Valor_Pago { get; set; }
        public Decimal Valor_Pago_Real { get; set; }
        public int? Numero_Execucao { get; set; }
        public int? Ano_execucao { get; set; }
        public string Processo_CNJ { get; set; }
        public bool? Registrado { get; set; }
    }


}

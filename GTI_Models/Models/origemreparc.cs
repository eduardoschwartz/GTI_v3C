using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Origemreparc {
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
        public decimal? Principal { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Correcao { get; set; }
    }

    public class OrigemReparcStruct {
        public string Numero_Processo_Unificado { get; set; }
        public int Ano_Processo { get; set; }
        public int Numero_Processo { get; set; }
        public int Codigo { get; set; }
        public short Exercicio { get; set; }
        public short Lancamento_Codigo { get; set; }
        public string Lancamento_Descricao { get; set; }
        public byte Sequencia { get; set; }
        public byte Parcela { get; set; }
        public byte Complemento { get; set; }
        public decimal? Principal { get; set; }
        public decimal? Juros { get; set; }
        public decimal? Multa { get; set; }
        public decimal? Correcao { get; set; }
    }


}

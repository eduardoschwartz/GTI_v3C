using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Laseriptu {
        [Key]
        [Column(Order =1)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codreduzido { get; set; }
        public decimal? Vvt { get; set; }
        public decimal? Vvc { get; set; }
        public decimal? Vvi { get; set; }
        public decimal? Impostopredial { get; set; }
        public decimal? Impostoterritorial { get; set; }
        public string Natureza { get; set; }
        public decimal? Areaconstrucao { get; set; }
        public decimal? Testadaprinc { get; set; }
        public decimal? Valortotalparc { get; set; }
        public decimal? Valortotalunica { get; set; }
        public decimal? Valortotalunica2 { get; set; }
        public decimal? Valortotalunica3 { get; set; }
        public short? Qtdeparc { get; set; }
        public decimal? Txexpparc { get; set; }
        public decimal? Txexpunica { get; set; }
        public decimal? Areaterreno { get; set; }
        public decimal? Fatorcat { get; set; }
        public decimal? Fatorped { get; set; }
        public decimal? Fatorsit { get; set; }
        public decimal? Fatorpro { get; set; }
        public decimal? Fatortop { get; set; }
        public decimal? Fatordis { get; set; }
        public decimal? Fatorgle { get; set; }
        public decimal? Agrupamento { get; set; }
        public decimal? Fracaoideal { get; set; }
        public decimal? Aliquota { get; set; }
        public byte? Cpf { get; set; }
        public byte? Carne_web { get; set; }
    }
}

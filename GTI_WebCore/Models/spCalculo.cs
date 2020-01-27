using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class SpCalculo {
        [Key]
        [Column(Order =1)]
        public int Codigo{ get; set; }
        [Key]
        [Column(Order = 2)]
        public int Ano { get; set; }
        public decimal Vvt { get; set; }
        public decimal Vvp { get; set; }
        public decimal Vvi { get; set; }
        public decimal Areapredial { get; set; }
        public decimal Areaterreno { get; set; }
        public byte Tipoisencao { get; set; }
        public string Descisencao { get; set; }
        public decimal Percisencao { get; set; }
        public short Qtdeimoveis { get; set; }
        public string Natureza { get; set; }
        public decimal Valoriptu { get; set; }
        public decimal Valoritu { get; set; }
        public decimal Aliquota { get; set; }
        public byte Qtdeparc { get; set; }
        public decimal Valorparcela { get; set; }
        public decimal Valorunica { get; set; }
        public decimal Valorunica2 { get; set; }
        public decimal Valorunica3 { get; set; }
        public decimal Valorfinalfull { get; set; }
        public decimal Valorexp { get; set; }
        public decimal Testadaprinc { get; set; }
        public decimal Fcat { get; set; }
        public decimal Fped{ get; set; }
        public decimal Fsit { get; set; }
        public decimal Fpro { get; set; }
        public decimal Ftop { get; set; }
        public decimal Fdis { get; set; }
        public decimal Fgle { get; set; }
        public short Agrupamento { get; set; }
        public decimal Fracao { get; set; }
        public decimal Valorfinal { get; set; }
        public decimal Valoragrupamento { get; set; }
        public string Ativo { get; set; }
        public bool Residente { get; set; }
    }
}

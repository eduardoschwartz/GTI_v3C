using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tributo {
        [Key]
        [Index("Tributo_Index", IsUnique = true, Order = 1)]
        public short Codtributo { get; set; }
        public string Desctributo { get; set; }
        public string Abrevtributo { get; set; }
        public bool Da { get; set; }
        public int? Ficha { get; set; }
        public string Nat_ficha { get; set; }
        public int? Fichajrmulta { get; set; }
        public string Nat_jrmulta { get; set; }
        public int? Fichadivida { get; set; }
        public string Nat_divida { get; set; }
        public int? Fichadajrmul { get; set; }
        public string Nat_dajrmul { get; set; }
        public int? Fichadaenca { get; set; }
        public string Nat_daenca { get; set; }
        public int? Fichaajuiza { get; set; }
        public string Nat_ajuiza { get; set; }
        public int? Fichaajjrmul { get; set; }
        public string Nat_ajjrmul { get; set; }
        public int? Fichaajenca { get; set; }
        public string Nat_ajenca { get; set; }
        public bool? Juros { get; set; }
        public bool? Multa { get; set; }
        public byte? Livro { get; set; }
    }
}

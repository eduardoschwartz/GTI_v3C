using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Lancamento {
        [Key]
        public short Codlancamento { get; set; }
        public string Descfull { get; set; }
        public string Descreduz { get; set; }
        public short? Tipolivro { get; set; }
    }

   
}

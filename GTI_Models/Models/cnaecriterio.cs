using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Cnaecriterio {
        public string Secao { get; set; }
        public int Divisao { get; set; }
        public int Grupo { get; set; }
        public int Classe { get; set; }
        public int Subclasse { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Seq { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Criterio { get; set; }
        public decimal Valor { get; set; }
        [Key]
        [Column(Order = 3)]
        public string Cnae { get; set; }
    }

    public class CnaecriterioStruct {
        public string Cnae { get; set; }
        public int Criterio { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
    }


}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Mobiliariovs {
        [Key]
        [Column(Order =1)]
        public int Codigo { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Cnae { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Criterio { get; set; }
        public int? Qtde { get; set; }
    }

    public class MobiliariovsStruct {
        public int Codigo { get; set; }
        public string Cnae { get; set; }
        public int Criterio { get; set; }
        public int? Qtde { get; set; }
        public decimal? Valor { get; set; }
    }
}

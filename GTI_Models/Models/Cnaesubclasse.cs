using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class cnaesubclasse {
        [Key]
        [Column(Order = 1)]
        public string Secao { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Divisao { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Grupo { get; set; }
        [Key]
        [Column(Order = 4)]
        public int Classe { get; set; }
        [Key]
        [Column(Order = 5)]
        public int Subclasse { get; set; }
        public string Descricao { get; set; }
    }

    public class CnaeStruct {
        public string CNAE { get; set; }
        public int Divisao { get; set; }
        public int Grupo { get; set; }
        public int Classe { get; set; }
        public int Subclasse { get; set; }
        public string Descricao { get; set; }
        public bool Principal { get; set; }
        public int Criterio { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }
    }

}

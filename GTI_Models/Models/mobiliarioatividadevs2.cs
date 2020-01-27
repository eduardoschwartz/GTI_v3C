using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GTI_Models.Models {
    public class Mobiliarioatividadevs2 {
        [Key]
        [Column(Order = 1)]
        public int Codmobiliario { get; set; }
        [Key]
        [StringLength(1)]
        [Column(Order = 2)]
        public string Secao { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Divisao { get; set; }
        [Key]
        [Column(Order = 4)]
        public int Grupo { get; set; }
        [Key]
        [Column(Order = 5)]
        public int Classe { get; set; }
        [Key]
        [Column(Order = 6)]
        public int Subclasse { get; set; }
        [Key]
        [Column(Order = 7)]
        public int Criterio { get; set; }
        public int Qtde { get; set; }
        public decimal Valor { get; set; }
    }
}

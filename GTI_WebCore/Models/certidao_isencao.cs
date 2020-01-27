using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Certidao_isencao {
        [Key]
        [Column(Order = 1)]
        public int Numero { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Ano { get; set; }
        public DateTime Data { get; set; }
        public int Codigo { get; set; }
        public string Nomecidadao { get; set; }
        public string Inscricao { get; set; }
        public string Logradouro { get; set; }
        public int Li_num { get; set; }
        public string Li_compl { get; set; }
        public string Li_quadras { get; set; }
        public string Li_lotes { get; set; }
        public string Descbairro { get; set; }
        public decimal? Percisencao { get; set; }
        public decimal? Area { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? Dataprocesso { get; set; }
    }
}

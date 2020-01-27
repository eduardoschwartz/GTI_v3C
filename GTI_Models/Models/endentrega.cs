using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Endentrega {
        [Key]
        public int Codreduzido { get; set; }
        public int? Ee_codlog { get; set; }
        public string Ee_nomelog { get; set; }
        public short? Ee_numimovel { get; set; }
        public string Ee_complemento { get; set; }
        public string Ee_uf { get; set; }
        public short? Ee_cidade { get; set; }
        public short? Ee_bairro { get; set; }
        public string Ee_cep { get; set; }
        public short? Ee_loteamento { get; set; }
        public string Ee_descbairro { get; set; }
    }
}

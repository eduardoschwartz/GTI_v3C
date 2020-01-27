using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Vre_licenciamento {
        [Key]
        [Column(Order =1)]
        public int Empresa_id { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Solicitacao_id { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Orgao_id { get; set; }
        public int? Status { get; set; }
        public bool? Risco { get; set; }
        public string Numero { get; set; }
        public DateTime? Data_emissao { get; set; }
        public DateTime? Data_vencimento { get; set; }
    }
}

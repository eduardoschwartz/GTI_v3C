
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Atividadeiss {
        [Key]
        public int Codatividade { get; set; }
        public string Descatividade { get; set; }
        public string Item { get; set; }
        public byte? Isseletronico { get; set; }
        public string Retido { get; set; }
        public byte? Imprimir { get; set; }
    }

    public class AtividadeIssStruct {
        public int Codigo_atividade { get; set; }
        public int Tipo { get; set; }
        public string Tipo_str { get; set; }
        public string Descricao { get; set; }
        public int? Quantidade { get; set; }
        public float Aliquota { get; set; }
    }

}

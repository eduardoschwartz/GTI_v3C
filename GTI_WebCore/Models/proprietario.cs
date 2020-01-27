using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Proprietario {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Codcidadao { get; set; }
        public string Tipoprop { get; set; }
        public bool Principal { get; set; }
    }


    public class ProprietarioStruct {
        public int CodigoImovel { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public bool Principal { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string RG { get; set; }
    }


}

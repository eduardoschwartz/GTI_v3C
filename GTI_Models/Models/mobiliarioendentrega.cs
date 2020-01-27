using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class mobiliarioendentrega {
        [Key]
        [Column(Order = 1)]
        public int Codmobiliario { get; set; }
        [Key]
        [Column(Order = 2)]
        public byte Tipo { get; set; }
        public int Codlogradouro { get; set; }
        public string Nomelogradouro { get; set; }
        public short Numimovel { get; set; }
        public string Complemento { get; set; }
        public string Uf{ get; set; }
        public short Codcidade { get; set; }
        public short Codbairro { get; set; }
        public string Cep { get; set; }
        public string Descbairro { get; set; }
        public string Desccidade { get; set; }
    }
}

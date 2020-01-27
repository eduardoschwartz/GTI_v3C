using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Assunto {
        [Key]
        public short Codigo { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}

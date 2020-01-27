using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Horario_funcionamento {
        [Key]
        public int Id { get; set; }
        public string descricao { get; set; }
    }
}

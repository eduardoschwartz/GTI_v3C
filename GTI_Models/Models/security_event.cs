using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class security_event {
        [Key]
        public int Id { get; set; }
        public int IdMaster { get; set; }
        public string Descricao { get; set; }
    }
}

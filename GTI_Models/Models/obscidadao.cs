using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class obscidadao {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public DateTime timestamp { get; set; }
        public string Obs { get; set; }
        public int? Userid { get; set; }
    }

    public class Observacao_CidadaoStruct {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public DateTime? Data_Hora { get; set; }
        public string Obs { get; set; }
        public int? Id_Usuario { get; set; }
        public string Nome_Usuario { get; set; }
    }
}

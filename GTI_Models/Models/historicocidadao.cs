using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class historicocidadao {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public DateTime? Data { get; set; }
        public string Obs { get; set; }
        public int? Userid { get; set; }
    }

    public class Historico_CidadaoStruct {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public DateTime? Data { get; set; }
        public string Obs { get; set; }
        public int? Id_Usuario { get; set; }
        public string Nome_Usuario { get; set; }
    }
}

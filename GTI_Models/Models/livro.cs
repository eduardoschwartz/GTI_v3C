using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Livro {
        [Key]
        public short Numero { get; set; }
        public short? Codtipo { get; set; }
        public short? Ano { get; set; }
        public DateTime? Dataabertura { get; set; }
        public DateTime? Dataencerramento { get; set; }
    }

    public class LivroStruct {
        public short Numero { get; set; }
        public short? Tipo_Codigo { get; set; }
        public string Tipo_Descricao { get; set; }
        public short? Ano { get; set; }
        public DateTime? Data_Abertura { get; set; }
        public DateTime? Data_Encerramento { get; set; }
    }


}

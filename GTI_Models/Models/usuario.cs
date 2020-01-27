using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Usuario {
        [Required]
        [StringLength(30)]
        [Key]
        public string Nomelogin { get; set; }
        [Required]
        [StringLength(50)]
        public string Nomecompleto { get; set; }
        public byte? Ativo { get; set; }
        public byte? Logon { get; set; }
        public DateTime? Datalogon { get; set; }
        public bool? Fiscal { get; set; }
        public string Senha { get; set; }
        public string Grupo { get; set; }
        public string Senha2 { get; set; }
        public int? Setor_atual { get; set; }
        public int? Id { get; set; }
        public string Userbinary { get; set; }
    }

    public class usuarioStruct {
        [Key]
        public string Nome_login { get; set; }
        public string Nome_completo { get; set; }
        public byte? Ativo { get; set; }
        public byte? Logon { get; set; }
        public DateTime Data_logon { get; set; }
        public bool Fiscal { get; set; }
        public string Senha { get; set; }
        public string Grupo { get; set; }
        public string Senha2 { get; set; }
        public int? Setor_atual { get; set; }
        public int? Id { get; set; }
        public string Nome_setor { get; set; }
        public string Userbinary { get; set; }
    }
}

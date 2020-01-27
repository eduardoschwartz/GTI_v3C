using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Tb_inter_encerramento_giss {
        [Key]
        [Column(Order =1)]
        public decimal Num_cadastro { get; set; }
        [Key]
        [Column(Order = 2)]
        public decimal Mes_competencia { get; set; }
        [Key]
        [Column(Order = 3)]
        public decimal Ano_competencia { get; set; }
        public int Cod_cliente { get; set; }
        public DateTime Data_encerramento { get; set; }
        public string Tipo_modalidade { get; set; }
        public string Ip { get; set; }
        public string Sem_movimento { get; set; }
        public DateTime Timestamp { get; set; }
        public string Controle { get; set; }
    }
}

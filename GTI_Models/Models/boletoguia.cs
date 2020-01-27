using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Boletoguia {
        [Key]
        [Column(Order=1)]
        public int Sid { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Seq { get; set; }
        public string Usuario { get; set; }
        public string Computer { get; set; }
        public string Codreduzido { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public short Numimovel { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Fulllanc { get; set; }
        public string Numdoc { get; set; }
        public short Numparcela { get; set; }
        public short Totparcela { get; set; }
        public DateTime? Datavencto { get; set; }
        public string Numdoc2 { get; set; }
        public string Digitavel { get; set; }
        public string Codbarra { get; set; }
        public decimal? Valorguia { get; set; }
        public string Obs { get; set; }
        public string Numproc { get; set; }
        public string Cep { get; set; }
        public string Numbarra2a { get; set; }
        public string Numbarra2b { get; set; }
        public string Numbarra2c { get; set; }
        public string Numbarra2d { get; set; }
        public string Desclanc { get; set; }
        public string Nossonumero { get; set; }
        public string Parcela { get; set; }
        public string Quadra { get; set; }
        public string Lote { get; set; }
        public DateTime? Datadoc { get; set; }
        public string Inscricao_cadastral { get; set; }
        public decimal? Valor_ISS { get; set; }
        public decimal? Valor_Taxa { get; set; }
    }
}

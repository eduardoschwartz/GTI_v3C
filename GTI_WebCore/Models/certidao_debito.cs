using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_WebCore.Models {
    public class Certidao_debito {
        [Key]
        [Column(Order =1)]
        public int Numero { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Ano { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Ret { get; set; }
        public string Lancamento { get; set; }
        public string Suspenso { get; set; }
        public int? Codigo { get; set; }
        public string Processo { get; set; }
        public DateTime Dataprocesso { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public short? Numimovel { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Atendente { get; set; }
        public string Inscricao { get; set; }
        public string Atividade { get; set; }
        public DateTime Datagravada { get; set; }
    }

    public class Certidao_debito_detalhe {
        public Functions.RetornoCertidaoDebito Tipo_Retorno { get; set; }
        public string Descricao_Lancamentos { get; set; }
    }


}

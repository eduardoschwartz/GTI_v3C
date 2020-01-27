using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Processoreparc {
        [Key]
        public string Numprocesso { get; set; }
        public int? Numproc { get; set; }
        public short? Anoproc { get; set; }
        public DateTime? Dataprocesso { get; set; }
        public DateTime? Datareparc { get; set; }
        public byte? Qtdeparcela { get; set; }
        public decimal? Valorentrada { get; set; }
        public decimal? Percentrada { get; set; }
        public bool? Calculamulta { get; set; }
        public bool? Calculajuros { get; set; }
        public bool? Calculacorrecao { get; set; }
        public bool? Penhora { get; set; }
        public bool? Honorario { get; set; }
        public int Codigoresp { get; set; }
        public string Funcionario { get; set; }
        public bool? Cancelado { get; set; }
        public DateTime? Datacancel { get; set; }
        public string Funcionariocancel { get; set; }
        public string Numprotocolo { get; set; }
        public string Plano { get; set; }
        public bool? Novo { get; set; }
        public DateTime? Data_exportacao { get; set; }
        public int? Userid { get; set; }
    }

    public class Processo_Numero {
        public string Numero_processo { get; set; }
        public int? Numero { get; set; }
        public short? Ano { get; set; }
    }

    public class Processo_Parcelamento_Struct {
        [Key]
        public string Numero_Processo_Unificado { get; set; }
        public int? Numero_Processo { get; set; }
        public short? Ano_Processo { get; set; }
        public DateTime? Data_Processo { get; set; }
        public DateTime? Data_Parcelamento { get; set; }
        public byte? Qtde_Parcela { get; set; }
        public decimal? Valor_Entrada { get; set; }
        public decimal? Percentual_Entrada { get; set; }
        public bool? Calcula_Multa { get; set; }
        public bool? Calcula_Juros { get; set; }
        public bool? Calcula_Correcao { get; set; }
        public bool? Penhora { get; set; }
        public bool? Honorario { get; set; }
        public int Codigo_Reduzido { get; set; }
        public string Funcionario { get; set; }
        public bool? Cancelado { get; set; }
        public DateTime? Data_Cancelado { get; set; }
        public string Funcionario_Cancelado { get; set; }
        public string Numero_Protocolo { get; set; }
        public string Plano { get; set; }
        public bool? Novo { get; set; }
        public DateTime? Data_Exportacao { get; set; }
        public int? Userid { get; set; }
        public string Usuario_Nome { get; set; }
    }



}

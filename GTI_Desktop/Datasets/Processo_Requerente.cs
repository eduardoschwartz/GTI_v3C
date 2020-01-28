using System;

namespace GTI_Desktop.Datasets {
    public class Processo_Requerente {
        public int Ano_Processo { get; set; }
        public int Num_Processo { get; set; }
        public int Seq { get; set; }
        public string Numero_Processo { get; set; }
        public string Assunto { get; set; }
        public DateTime Data_Entrada { get; set; }
        public string Requerente { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Endereco_Imovel { get; set; }
        public string Rg { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI_v4.ReportModels {
    public class Processo_Documento {
        public int Ano_Processo { get; set; }
        public int Num_Processo { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Entrega { get; set; }
    }
}

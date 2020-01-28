using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTI_Desktop.Datasets {
    public class Detalhe_Parcela_Tributo {
		public int Codigo { get; set; }
		public int Exercicio { get; set; }
		public int Lanc { get; set; }
		public int Seq { get; set; }
		public int Parc { get; set; }
		public int Compl { get; set; }
		public int Codtributo { get; set; }
		public string Desctributo { get; set; }
		public decimal Principal { get; set; }
		public decimal Juros { get; set; }
		public decimal Multa { get; set; }
		public decimal Correcao { get; set; }
		public decimal Total { get; set; }
	}
}

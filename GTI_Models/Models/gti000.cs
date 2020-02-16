using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Gti000 {
        [Key]
        public int UserId { get; set; }
        public string Path_Anexo { get; set; }
        public string Path_Report { get; set; }
        public int Form_Processo_Lista_Width { get; set; }
        public int Form_Processo_Lista_Height { get; set; }
        public int Form_Processo_Tramite_Width { get; set; }
        public int Form_Processo_Tramite_Height { get; set; }
        public int Form_Report_Width { get; set; }
        public int Form_Report_Height { get; set; }
        public int Form_Extrato_Width { get; set; }
        public int Form_Extrato_Height { get; set; }
    }



}

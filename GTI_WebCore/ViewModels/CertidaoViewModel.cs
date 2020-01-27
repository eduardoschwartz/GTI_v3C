using GTI_WebCore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GTI_WebCore.ViewModels {
    public class CertidaoViewModel {
        public ImovelStruct ImovelStruct { get; set; }
        [Display(Name = "Inscrição Municipal")]
        public string Inscricao { get; set; }
        public string SelectedValue { get; set; }
        public List<SelectListItem> OptionList { get; set; }
        public string CpfValue { get; set; }
        public string CnpjValue { get; set; }
        public string ErrorMessage { get; set; }
        [Required]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
        [Display(Name = "Chave de validação")]
        public string Chave { get; set; }
        public bool Extrato { get; set; }
    }
}

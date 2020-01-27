using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.ViewModels {
    public class EmpresaDetailsViewModel {
        public EmpresaStruct EmpresaStruct { get; set; }
        [Display(Name = "Inscrição Municipal")]
        public string Inscricao { get; set; }
        public string CpfCnpjLabel { get; set; }
        public string CpfValue { get; set; }
        public string CnpjValue { get; set; }
        public string TaxaLicenca { get; set; }
        public string Vigilancia_Sanitaria { get; set; }
        public string Regime_Iss { get; set; }
        public string Mei { get; set; }
        public string Cnae { get; set; }
        public string ErrorMessage { get; set; }
        [Required]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
    }
}

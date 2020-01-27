using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.Models.ReportModels;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GTI_WebCore.Controllers {

    [Route("Empresa")]
    public class EmpresaController : Controller {
        private readonly IEmpresaRepository empresaRepository;
        private readonly ITributarioRepository tributarioRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public EmpresaController(IEmpresaRepository empresaRepository, ITributarioRepository tributarioRepository,IHostingEnvironment hostingEnvironment) {
            this.empresaRepository = empresaRepository;
            this.tributarioRepository = tributarioRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("Details")]
        [HttpGet]
        public ViewResult Details() {
            return View();
        }

       
        [Route("Details")]
        [HttpPost]
        public ViewResult Details(EmpresaDetailsViewModel model) {
            int _codigo = 0;
            bool _existeCod = false;
            EmpresaDetailsViewModel empresaDetailsViewModel = new EmpresaDetailsViewModel();

            if (model.Inscricao != null) {
                _codigo = Convert.ToInt32(model.Inscricao);
                if (_codigo >= 100000 && _codigo < 210000) //Se estiver fora deste intervalo nem precisa checar se a empresa existe
                    _existeCod = empresaRepository.Existe_Empresa_Codigo(_codigo);
            } else {
                if (model.CnpjValue != null) {
                    string _cnpj = model.CnpjValue;
                    bool _valida = Functions.ValidaCNPJ(_cnpj); //CNPJ válido?
                    if (_valida) {
                        _codigo = empresaRepository.Existe_Empresa_Cnpj(_cnpj);
                        if (_codigo > 0)
                            _existeCod = true;
                    } else {
                        empresaDetailsViewModel.ErrorMessage = "Cnpj inválido.";
                        return View(empresaDetailsViewModel);
                    }
                } else {
                    if (model.CpfValue != null) {
                        string _cpf = model.CpfValue;
                        bool _valida = Functions.ValidaCpf(_cpf); //CPF válido?
                        if (_valida) {
                            _codigo = empresaRepository.Existe_Empresa_Cpf(_cpf);
                            if (_codigo > 0)
                                _existeCod = true;

                        } else {
                            empresaDetailsViewModel.ErrorMessage = "Cpf inválido.";
                            return View(empresaDetailsViewModel);
                        }
                    }
                }
            }


            if (!Captcha.ValidateCaptchaCode(model.CaptchaCode, HttpContext)) {
                empresaDetailsViewModel.ErrorMessage = "Código de verificação inválido.";
                return View(empresaDetailsViewModel);
            }


            if (_existeCod) {
                EmpresaStruct empresa = empresaRepository.Dados_Empresa(_codigo);
                empresaDetailsViewModel.EmpresaStruct = empresa;
                empresaDetailsViewModel.TaxaLicenca = empresaRepository.Empresa_tem_TL(_codigo) ? "Sim" : "Não";
                empresaDetailsViewModel.Vigilancia_Sanitaria = empresaRepository.Empresa_tem_VS(_codigo) ? "Sim" : "Não";
                empresaDetailsViewModel.Mei = empresaRepository.Empresa_Mei(_codigo) ? "Sim" : "Não";
                List<CnaeStruct> ListaCnae = empresaRepository.Lista_Cnae_Empresa(_codigo);
                string sCnae = "";
                foreach (CnaeStruct cnae in ListaCnae) {
                    sCnae += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
                }
                empresaDetailsViewModel.Cnae = sCnae;
                string sRegime = empresaRepository.Regime_Empresa(_codigo);
                if (sRegime == "F")
                    sRegime = "ISS FIXO";
                else {
                    if (sRegime == "V")
                        sRegime = "ISS VARIÁVEL";
                    else {
                        if (sRegime == "E")
                            sRegime = "ISS ESTIMADO";
                        else
                            sRegime = "NENHUM";
                    }
                }
                empresaDetailsViewModel.Regime_Iss = sRegime;
                empresaDetailsViewModel.ErrorMessage = "";
                return View("DetailsTable", empresaDetailsViewModel);
            } else {
                empresaDetailsViewModel.ErrorMessage = "Empresa não cadastrada.";
                return View(empresaDetailsViewModel);
            }

        }

        [Route("get-captcha-image")]
        public IActionResult GetCaptchaImage() {
            int width = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }

        [Route("Certidao/Certidao_Inscricao")]
        [HttpGet]
        public ViewResult Certidao_Inscricao() {
            CertidaoViewModel model = new CertidaoViewModel {
                OptionList = new List<SelectListItem> {
                new SelectListItem { Text = " CPF", Value = "cpfCheck", Selected = true },
                new SelectListItem { Text = " CNPJ", Value = "cnpjCheck", Selected = false }
            },
                SelectedValue = "cpfCheck"
            };
            return View(model);
        }

        [Route("Retorna_Codigos")]
        [Route("Certidao/Retorna_Codigos")]
        public IActionResult Retorna_Codigos(CertidaoViewModel model) {
            if(model.CpfValue!=null || model.CnpjValue != null) {

                model.OptionList = new List<SelectListItem> {
                    new SelectListItem { Text = " CPF", Value = "cpfCheck", Selected = model.SelectedValue == "cpfCheck" },
                    new SelectListItem { Text = " CNPJ", Value = "cnpjCheck", Selected = model.SelectedValue == "cnpjCheck" }
                };

                List<int> _lista = new List<int>();
                if (model.CpfValue != null) {
                    _lista = empresaRepository.Retorna_Codigo_por_CPF(Functions.RetornaNumero(model.CpfValue));
                } else {
                    if (model.CnpjValue != null) {
                        _lista = empresaRepository.Retorna_Codigo_por_CNPJ(Functions.RetornaNumero(model.CnpjValue));
                    }
                }
                if (_lista.Count > 0) {
                    ViewBag.Lista_Codigo = _lista;
                    return View("Certidao_Inscricao", model);
                } else {
                    ViewBag.Result = "Não foi localizada nenhuma empresa cadastrada com o CPF/CNPJ informado.";
                    return View("Certidao_Inscricao", model);
                }
            }
            ViewBag.Result = "Informe o CPF ou o CNPJ para busca.";
            return View("Certidao_Inscricao",model);
        }

        [HttpPost]
        [Route("Validate_CI")]
        [Route("Certidao/Validate_CI")]
        public IActionResult Validate_CI(CertidaoViewModel model) {
            int _codigo , _ano ,_numero;
            string _chave = model.Chave;

            model.OptionList = new List<SelectListItem> {
                new SelectListItem { Text = " CPF", Value = "cpfCheck", Selected = model.SelectedValue == "cpfCheck" },
                new SelectListItem { Text = " CNPJ", Value = "cnpjCheck", Selected = model.SelectedValue == "cnpjCheck" }
            };

            if (model.Chave != null) {
                chaveStruct _chaveStruct = tributarioRepository.Valida_Certidao(_chave);
                if (!_chaveStruct.Valido) {
                    ViewBag.Result = "Chave de autenticação da certidão inválida.";
                    return View("Certidao_Inscricao", model);
                } else {
                    _codigo = _chaveStruct.Codigo;
                    _numero = _chaveStruct.Numero;
                    _ano = _chaveStruct.Ano;
                    List<Comprovante_Inscricao> certidao = new List<Comprovante_Inscricao>();
                    Certidao_Inscricao _dados = tributarioRepository.Retorna_Certidao_Inscricao(_ano, _numero);
                    if (_dados != null) {
                        Comprovante_Inscricao reg = new Comprovante_Inscricao() {
                            Codigo = _codigo,
                            Razao_Social = _dados.Nome,
                            Nome_Fantasia = _dados.Nome_fantasia,
                            Cep = _dados.Cep,
                            Cidade = _dados.Cidade,
                            Email = _dados.Email,
                            Inscricao_Estadual = _dados.Inscricao_estadual,
                            Endereco = _dados.Endereco + ", " + _dados.Numero,
                            Complemento = _dados.Complemento,
                            Bairro = _dados.Bairro ?? "",
                            Ano = _ano,
                            Numero = _numero,
                            Controle = _chave,
                            Atividade = _dados.Atividade,
                            Atividade2 = _dados.Atividade_secundaria,
                            Atividade_Extenso=_dados.Atividade_Extenso,
                            Cpf_Cnpj = _dados.Documento,
                            Data_Abertura = (DateTime)_dados.Data_abertura,
                            Processo_Abertura = _dados.Processo_abertura,
                            Processo_Encerramento = _dados.Processo_encerramento,
                            Situacao = _dados.Situacao,
                            Telefone = _dados.Telefone,
                            Area = (decimal)_dados.Area,
                            Mei = _dados.Mei,
                            Vigilancia_Sanitaria = _dados.Vigilancia_sanitaria,
                            Taxa_Licenca = _dados.Taxa_licenca
                        };
                        if (_dados.Data_encerramento != null)
                            reg.Data_Encerramento = (DateTime)_dados.Data_encerramento;
                        certidao.Add(reg);
                    } else {
                        ViewBag.Result = "Ocorreu um erro ao processar as informações.";
                        return View("Certidao_Inscricao", model);
                    }

                    ReportDocument rd = new ReportDocument();
                    rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Comprovante_Inscricao_Valida.rpt");

                    try {
                        rd.SetDataSource(certidao);
                        Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
                        return File(stream, "application/pdf", "Certidao_Endereco.pdf");
                    } catch {

                        throw;
                    }
                }
            } else {
                ViewBag.Result = "Chave de validação inválida.";
                return View("Certidao_Inscricao", model);
            }
        }


        [Route("Certidao_Inscricao")]
        [Route("Certidao/Certidao_Inscricao")]
        [HttpPost]
        public IActionResult Certidao_Inscricao(CertidaoViewModel model) {
            int _codigo;
            bool _valida = false;
            int _numero;
            _numero = tributarioRepository.Retorna_Codigo_Certidao(Functions.TipoCertidao.Debito);
            ViewBag.Result = "";

            model.OptionList = new List<SelectListItem> {
                new SelectListItem { Text = " CPF", Value = "cpfCheck", Selected = model.SelectedValue == "cpfCheck" },
                new SelectListItem { Text = " CNPJ", Value = "cnpjCheck", Selected = model.SelectedValue == "cnpjCheck" }
            };

            if (model.CpfValue != null || model.CnpjValue != null) {
                List<int> _lista = new List<int>();
                if (model.CpfValue != null) {
                    _lista = empresaRepository.Retorna_Codigo_por_CPF(Functions.RetornaNumero(model.CpfValue));
                } else {
                    if (model.CnpjValue != null) {
                        _lista = empresaRepository.Retorna_Codigo_por_CNPJ(Functions.RetornaNumero(model.CnpjValue));
                    }
                }
                if (_lista.Count > 0) {
                    ViewBag.Lista_Codigo = _lista;
                } 
            }

            if (!Captcha.ValidateCaptchaCode(model.CaptchaCode, HttpContext)) {
                ViewBag.Result = "Código de verificação inválido.";
                return View(model);
            }
            
            if (model.Inscricao != null) {
                _codigo = Convert.ToInt32(model.Inscricao);
            } else {
                ViewBag.Result = "Erro ao recuperar as informações.";
                return View(model);
            }

            EmpresaStruct _dados = empresaRepository.Dados_Empresa(_codigo);
            string _sufixo = model.Extrato ? _dados.Data_Encerramento == null ? "XA" : "XE" : "IE";
            List<CnaeStruct> ListaCnae = empresaRepository.Lista_Cnae_Empresa(_codigo);
            string _cnae = "", _cnae2 = "";
            foreach (CnaeStruct cnae in ListaCnae) {
                if (cnae.Principal)
                    _cnae = cnae.CNAE + "-" + cnae.Descricao;
                else
                    _cnae2 += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
            }

            Comprovante_Inscricao reg = new Comprovante_Inscricao() {
                Codigo = _codigo,
                Data_Emissao=DateTime.Now,
                Razao_Social=_dados.Razao_social,
                Nome_Fantasia=_dados.Nome_fantasia,
                Cep=_dados.Cep,
                Cidade=_dados.Cidade_nome + "/" + _dados.UF,
                Email=_dados.Email_contato,
                Inscricao_Estadual = _dados.Inscricao_estadual,
                Endereco = _dados.Endereco_nome +", " + _dados.Numero,
                Complemento = _dados.Complemento,
                Bairro = _dados.Bairro_nome ?? "",
                Ano = DateTime.Now.Year,
                Numero = _numero,
                Controle = _numero.ToString("00000") + DateTime.Now.Year.ToString("0000") + "/" + _codigo.ToString() + "-" + _sufixo,
                Atividade = _cnae,
                Atividade2 = _cnae2,
                Atividade_Extenso=_dados.Atividade_extenso,
                Cpf_Cnpj = _dados.Cpf_cnpj,
                Rg=_dados.Rg,
                Data_Abertura = (DateTime)_dados.Data_abertura,
                Processo_Abertura = _dados.Numprocesso,
                Processo_Encerramento = _dados.Numprocessoencerramento,
                Situacao=_dados.Situacao,
                Telefone=_dados.Fone_contato,
                Uf=_dados.UF,
                Area=(decimal)_dados.Area,
                Mei = Convert.ToBoolean(_dados.Mei) ? "SIM" : "NÃO",
                Vigilancia_Sanitaria = empresaRepository.Empresa_tem_VS(_codigo)?"SIM":"NÃO",
                Taxa_Licenca = empresaRepository.Empresa_tem_TL(_codigo) ? "SIM" : "NÃO"
            };
            if (_dados.Data_Encerramento != null)
                reg.Data_Encerramento = (DateTime)_dados.Data_Encerramento;

            Certidao_Inscricao reg2 = new Certidao_Inscricao() {
                Cadastro = reg.Codigo,
                Data_emissao=reg.Data_Emissao,
                Data_encerramento=reg.Data_Encerramento,
                Nome = reg.Razao_Social,
                Nome_fantasia = reg.Nome_Fantasia??"",
                Cep = reg.Cep??"",
                Cidade = reg.Cidade??"",
                Email = reg.Email??"",
                Inscricao_estadual = reg.Inscricao_Estadual??"",
                Endereco = reg.Endereco + ", " + reg.Numero,
                Complemento = reg.Complemento??"",
                Bairro = reg.Bairro ?? "",
                Ano = DateTime.Now.Year,
                Numero = _numero,
                Atividade = _cnae??"",
                Atividade_secundaria = _cnae2??"",
                Atividade_Extenso=reg.Atividade_Extenso,
                Rg = reg.Rg ?? "",
                Documento = reg.Cpf_Cnpj,
                Data_abertura = (DateTime)reg.Data_Abertura,
                Processo_abertura = reg.Processo_Abertura??"",
                Processo_encerramento = reg.Processo_Encerramento??"",
                Situacao = reg.Situacao,
                Telefone = reg.Telefone??"",
                Area = (decimal)reg.Area,
                Mei = reg.Mei,
                Vigilancia_sanitaria = reg.Vigilancia_Sanitaria,
                Taxa_licenca = reg.Taxa_Licenca
            };
            if (reg.Data_Encerramento != null)
                reg2.Data_encerramento = (DateTime)reg.Data_Encerramento;

            Exception ex = tributarioRepository.Insert_Certidao_Inscricao(reg2);
            if (ex != null)
                throw ex;

            List<Certidao> Lista_Certidao = new List<Certidao>();
            if (model.Extrato) {

                List<SpExtrato> ListaTributo = tributarioRepository.Lista_Extrato_Tributo(_codigo, 1980, 2050, 0, 99, 0, 99, 0, 999, 0, 99, 0, 99, DateTime.Now, "Web");
                List<SpExtrato> ListaParcela = tributarioRepository.Lista_Extrato_Parcela(ListaTributo);
                Certidao regCert = new Certidao();

                foreach (SpExtrato item in ListaParcela.Where(x => (x.Codlancamento == 2 || x.Codlancamento == 6 || x.Codlancamento == 14) && x.Statuslanc < 3)) {
                    Certidao_Inscricao_Extrato regExt = new Certidao_Inscricao_Extrato {
                        Id = reg.Controle,
                        Numero_certidao = reg.Numero,
                        Ano_certidao = (short)reg.Ano,
                        Ano = item.Anoexercicio,
                        Codigo = item.Codreduzido,
                        Complemento = item.Codcomplemento,
                    };
                    if (item.Datapagamento != null)
                        regExt.Data_Pagamento = Convert.ToDateTime(item.Datapagamento);
                    regExt.Data_Vencimento = item.Datavencimento;
                    regExt.Lancamento_Codigo = item.Codlancamento;
                    regExt.Lancamento_Descricao = item.Desclancamento;
                    regExt.Parcela = (byte)item.Numparcela;
                    regExt.Sequencia = (byte)item.Seqlancamento;
                    regExt.Valor_Pago = (decimal)item.Valorpagoreal;
                    ex = tributarioRepository.Insert_Certidao_Inscricao_Extrato(regExt);
                    if (ex != null)
                        throw ex;
                    regCert.Controle = _numero.ToString("00000") + DateTime.Now.Year.ToString("0000") + "/" + _codigo.ToString() + "-" + _sufixo;
                    regCert.Codigo = _codigo;
                    regCert.Razao_Social = reg2.Nome;
                    regCert.Nome_Requerente = reg2.Nome;
                    regCert.Data_Abertura = reg2.Data_abertura;
                    regCert.Processo_Encerramento = reg2.Processo_encerramento;
                    regCert.Endereco = reg2.Endereco;
                    regCert.Endereco_Numero = reg2.Numero;
                    regCert.Endereco_Complemento = reg2.Complemento;
                    regCert.Bairro = reg2.Bairro;
                    regCert.Cidade = reg2.Cidade ;
                    regCert.Atividade_Extenso = reg2.Atividade_Extenso;
                    regCert.Rg = reg2.Rg;
                    regCert.Cpf_Cnpj = reg2.Documento;
                    regCert.Exercicio = regExt.Ano;
                    regCert.Lancamento_codigo = (byte)regExt.Lancamento_Codigo;
                    regCert.Lancamento_Nome = regExt.Lancamento_Descricao;
                    regCert.Sequencia_Lancamento = regExt.Sequencia;
                    regCert.Complemento = regExt.Complemento;
                    regCert.Data_Vencimento = regExt.Data_Vencimento;
                    regCert.Data_Pagamento = regExt.Data_Pagamento;
                    regCert.Valor_Pago = regExt.Valor_Pago;
                    regCert.Processo_Abertura = reg2.Processo_abertura;
                    regCert.Numero_Ano = regExt.Numero_certidao.ToString("00000") + "/" + regExt.Ano_certidao;
                    if (reg2.Data_encerramento != null)
                        regCert.Data_Encerramento = (DateTime)reg.Data_Encerramento;

                    Lista_Certidao.Add(regCert);

                }
                if (Lista_Certidao.Count == 0) {
                    ViewBag.Result = "Esta empresa não possui débitos pagos de ISS/Taxa.";
                    return View(model);
                }

            }

            List<Comprovante_Inscricao> certidao = new List<Comprovante_Inscricao> {
                reg
            };

            ReportDocument rd = new ReportDocument();
            if (model.Extrato) {
                if (_dados.Data_Encerramento != null) {
                    rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\CertidaoInscricaoExtratoEncerrada.rpt");
                } else {
                    rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\CertidaoInscricaoExtratoAtiva.rpt");
                }
            } else {
                if (_valida) {
                    rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Comprovante_InscricaoValida.rpt");
                } else
                    rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Comprovante_Inscricao.rpt");
            }
            try {
                if (model.Extrato)
                    rd.SetDataSource(Lista_Certidao);
                else
                    rd.SetDataSource(certidao);
                Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
                return File(stream, "application/pdf", "Certidao_Inscricao.pdf");
            } catch {
                throw;
            }

        }


    }
}






using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Repository {
    public class RequerenteRepository:IRequerenteRepository {
        private readonly AppDbContext context;

        public RequerenteRepository(AppDbContext context) {
            this.context = context;
        }


        public CidadaoStruct Dados_Cidadao(int _codigo) {
                var Sql = (from c in context.Cidadao
                           join l in context.Logradouro on c.Codlogradouro equals l.Codlogradouro into lc from l in lc.DefaultIfEmpty()
                           join l2 in context.Logradouro on c.Codlogradouro2 equals l2.Codlogradouro into l2c from l2 in l2c.DefaultIfEmpty()
                           join a in context.Cidade on new { p1 = c.Siglauf, p2 = (short)c.Codcidade } equals new { p1 = a.Siglauf, p2 = a.Codcidade } into ac from a in ac.DefaultIfEmpty()
                           join a2 in context.Cidade on new { p1 = c.Siglauf, p2 = (short)c.Codcidade } equals new { p1 = a2.Siglauf, p2 = a2.Codcidade } into a2c from a2 in a2c.DefaultIfEmpty()
                           join b in context.Bairro on new { p1 = c.Siglauf, p2 = (short)c.Codcidade, p3 = (short)c.Codbairro } equals new { p1 = b.Siglauf, p2 = b.Codcidade, p3 = b.Codbairro } into bc from b in bc.DefaultIfEmpty()
                           join b2 in context.Bairro on new { p1 = c.Siglauf2, p2 = (short)c.Codcidade2, p3 = (short)c.Codbairro2 } equals new { p1 = b2.Siglauf, p2 = b2.Codcidade, p3 = b2.Codbairro } into b2c from b2 in b2c.DefaultIfEmpty()
                           where c.Codcidadao == _codigo
                           select new {
                               c.Codcidadao, c.Nomecidadao, c.Cpf, c.Data_nascimento, c.Cnpj, c.Etiqueta, c.Etiqueta2, c.Juridica, c.Profissao, c.Rg,
                               c.Orgao, c.Codlogradouro, c.Codlogradouro2, c.Nomelogradouro, c.Nomelogradouro2, c.Codbairro, c.Codbairro2, c.Codcidade, c.Codcidade2,
                               c.Siglauf, c.Siglauf2, c.Cep, c.Cep2, c.Codpais, c.Codpais2, c.Telefone, c.Telefone2, c.Email, c.Email2, c.Whatsapp, c.Whatsapp2, c.Numimovel,
                               c.Numimovel2, c.Complemento, c.Complemento2, c.Codprofissao, Endereco_NomeR = l.Endereco, Endereco_NomeC = l2.Endereco, Bairro_NomeR = b.Descbairro,
                               Bairro_NomeC = b2.Descbairro, Nome_CidadeR = a.Desccidade, Nome_CidadeC = a2.Desccidade
                           }).FirstOrDefault();

                CidadaoStruct reg = new CidadaoStruct() {
                    Codigo = Sql.Codcidadao,
                    Nome = Sql.Nomecidadao,
                    Cpf = Sql.Cpf,
                    Cnpj = Sql.Cnpj,
                    Rg = Sql.Rg,
                    Orgao = Sql.Orgao,
                    DataNascto = Sql.Data_nascimento,
                    EtiquetaR = Sql.Etiqueta,
                    EtiquetaC = Sql.Etiqueta2,
                    Juridica = Sql.Juridica == null ? false : (bool)Sql.Juridica,
                    Profissao = Sql.Profissao,
                    TelefoneR = Sql.Telefone,
                    TelefoneC = Sql.Telefone2,
                    EmailR = Sql.Email,
                    EmailC = Sql.Email2,
                    Whatsapp = Sql.Whatsapp,
                    Whatsapp2 = Sql.Whatsapp2,
                    CodigoLogradouroR = Sql.Codlogradouro,
                    CodigoLogradouroC = Sql.Codlogradouro2,
                    EnderecoR = Sql.Nomelogradouro,
                    EnderecoC = Sql.Nomelogradouro2,
                    NumeroR = Sql.Numimovel,
                    NumeroC = Sql.Numimovel2,
                    ComplementoR = Sql.Complemento,
                    ComplementoC = Sql.Complemento2,
                    CodigoBairroR = Sql.Codbairro,
                    CodigoBairroC = Sql.Codbairro2,
                    CodigoPaisR = Sql.Codpais,
                    CodigoPaisC = Sql.Codpais2,
                    CodigoCidadeR = Sql.Codcidade,
                    CodigoCidadeC = Sql.Codcidade2,
                    NomeCidadeR = Sql.Nome_CidadeR,
                    NomeCidadeC = Sql.Nome_CidadeC,
                    UfR = Sql.Siglauf,
                    UfC = Sql.Siglauf2,
                    CodigoProfissao = Sql.Codprofissao,
                    NomeBairroR = Sql.Bairro_NomeR,
                    NomeBairroC = Sql.Bairro_NomeC
                };
                if (Sql.Codlogradouro > 0)
                    reg.EnderecoR = Sql.Endereco_NomeR;
                if (Sql.Codlogradouro2 > 0)
                    reg.EnderecoC = Sql.Endereco_NomeC;

                if (!string.IsNullOrWhiteSpace(reg.Cnpj))
                    reg.Tipodoc = 1;
                else
                    reg.Tipodoc = 2;

                return reg;
        }


    }
}

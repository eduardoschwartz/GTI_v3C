using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTI_WebCore.Repository {
    public class ProcessoRepository:IProcessoRepository {
        private readonly AppDbContext context;

        public ProcessoRepository(AppDbContext context) {
            this.context = context;
        }

        public ProcessoStruct Dados_Processo(int nAno, int nNumero) {
            RequerenteRepository requerenteRepository = new RequerenteRepository(context);

            var reg = (from c in context.Processogti
                       join u in context.Usuario on c.Userid equals u.Id into uc from u in uc.DefaultIfEmpty()
                       where c.Ano == nAno && c.Numero == nNumero select new ProcessoStruct {
                           Ano = c.Ano, CodigoAssunto = c.Codassunto, AtendenteNome = u.Nomelogin, CentroCusto = (int)c.Centrocusto,
                           CodigoCidadao = (int)c.Codcidadao, Complemento = c.Complemento, DataArquivado = c.Dataarquiva, DataCancelado = c.Datacancel, DataEntrada = c.Dataentrada, DataReativacao = c.Datareativa,
                           DataSuspensao = c.Datasuspenso, Fisico = c.Fisico, Hora = c.Hora, Inscricao = (int)c.Insc, Interno = c.Interno, Numero = c.Numero, ObsArquiva = c.Obsa,
                           ObsCancela = c.Obsc, ObsReativa = c.Obsr, ObsSuspensao = c.Obss, Observacao = c.Observacao, Origem = c.Origem, TipoEnd = c.Tipoend, AtendenteId = (int)u.Id
                       }).FirstOrDefault();
            if (reg == null)
                return null;
            ProcessoStruct row = new ProcessoStruct {
                AtendenteNome = reg.AtendenteNome,
                AtendenteId = reg.AtendenteId,
                Dv = DvProcesso(nNumero)
            };
            row.SNumero = nNumero.ToString() + "-" + row.Dv.ToString() + "/" + nAno.ToString();
            row.Complemento = reg.Complemento;
            row.CodigoAssunto = Convert.ToInt32(reg.CodigoAssunto);
            row.Assunto = Retorna_Assunto(Convert.ToInt32(reg.CodigoAssunto));
            row.Observacao = reg.Observacao;
            row.Hora = reg.Hora == null ? "00:00" : reg.Hora.ToString();
            row.Inscricao = Convert.ToInt32(reg.Inscricao);
            row.DataEntrada = reg.DataEntrada;
            row.DataSuspensao = reg.DataSuspensao;
            row.DataReativacao = reg.DataReativacao;
            row.DataCancelado = reg.DataCancelado;
            row.DataArquivado = reg.DataArquivado;
            row.ListaAnexo = ListProcessoAnexo(nAno, nNumero);
            row.Anexo = ListProcessoAnexo(nAno, nNumero).Count().ToString() + " Anexo(s)";
            row.ListaAnexoLog = ListProcessoAnexoLog(nAno, nNumero);
            row.Interno = Convert.ToBoolean(reg.Interno);
            row.Fisico = Convert.ToBoolean(reg.Fisico);
            row.Origem = Convert.ToInt16(reg.Origem);
            if (!row.Interno) {
                row.CentroCusto = 0;
                row.CodigoCidadao = Convert.ToInt32(reg.CodigoCidadao);
                if (row.CodigoCidadao > 0) {
                    row.NomeCidadao = requerenteRepository.Dados_Cidadao((int)row.CodigoCidadao).Nome;
                } else
                    row.NomeCidadao = "";
            } else {
                row.CentroCusto = Convert.ToInt16(reg.CentroCusto);
                row.CodigoCidadao = 0;
                row.NomeCidadao = "";
            }
            row.ListaProcessoEndereco = ListProcessoEnd(nAno, nNumero);
            row.ObsArquiva = reg.ObsArquiva;
            row.ObsCancela = reg.ObsCancela;
            row.ObsReativa = reg.ObsReativa;
            row.ObsSuspensao = reg.ObsSuspensao;
            row.ListaProcessoDoc = ListProcessoDoc(nAno, nNumero);
            if (reg.TipoEnd == "1" || reg.TipoEnd == "2")
                row.TipoEnd = reg.TipoEnd.ToString();
            else
                row.TipoEnd = "R";
            return row;
        }

        public int DvProcesso(int Numero) {
            int soma = 0, index = 0, Mult = 6;
            string sNumProc = Numero.ToString().PadLeft(5, '0');
            while (index < 5) {
                int nChar = Convert.ToInt32(sNumProc.Substring(index, 1));
                soma += (Mult * nChar);
                Mult--;
                index++;
            }

            int DigAux = soma % 11;
            int Digito = 11 - DigAux;
            if (Digito == 10)
                Digito = 0;
            if (Digito == 11)
                Digito = 1;

            return Digito;
        }

        public string Retorna_Assunto(int Codigo) {
            string Sql = (from c in context.Assunto where c.Codigo == Codigo select c.Nome).FirstOrDefault();
            return Sql;
        }

        public List<ProcessoAnexoStruct> ListProcessoAnexo(int nAno, int nNumero) {
            var Sql = (from a in context.Anexo join p in context.Processogti on new { p1 = a.Anoanexo, p2 = a.Numeroanexo } equals new { p1 = p.Ano, p2 = p.Numero }
                       join c in context.Cidadao on p.Codcidadao equals c.Codcidadao into pc from c in pc.DefaultIfEmpty()
                       join u in context.Centrocusto on p.Centrocusto equals u.Codigo into pcu from u in pcu.DefaultIfEmpty()
                       where a.Ano == nAno && a.Numero == nNumero
                       select new ProcessoAnexoStruct { AnoAnexo = a.Anoanexo, NumeroAnexo = a.Numeroanexo, Complemento = p.Complemento, Requerente = c.Nomecidadao, CentroCusto = u.Descricao });
            return Sql.ToList();
        }

        public List<Anexo_logStruct> ListProcessoAnexoLog(int nAno, int nNumero) {
            var Sql = (from a in context.Anexo_Log
                       join u in context.Usuario on a.Userid equals u.Id into ac from u in ac.DefaultIfEmpty()
                       where a.Ano == nAno && a.Numero == nNumero
                       select new Anexo_logStruct {
                           Ano = (short)nAno, Numero = (short)nNumero, Ano_anexo = a.Ano_anexo, Numero_anexo = a.Numero_anexo,
                           Data = a.Data, Sid = a.Sid, Userid = a.Userid, Removido = a.Removido, Ocorrencia = a.Removido ? "Removido" : "Anexado", UserName = u.Nomecompleto
                       });
            return Sql.ToList();
        }

        public List<ProcessoDocStruct> ListProcessoDoc(int nAno, int nNumero) {
            var Sql = (from pd in context.Processodoc join d in context.Documento on pd.Coddoc equals d.Codigo where pd.Ano == nAno && pd.Numero == nNumero
                       select new ProcessoDocStruct { CodigoDocumento = pd.Coddoc, NomeDocumento = d.Nome, DataEntrega = pd.Data });
            return Sql.ToList();
        }

        public List<ProcessoEndStruct> ListProcessoEnd(int nAno, int nNumero) {
            var Sql = (from pe in context.Processoend join l in context.Logradouro on pe.Codlogr equals l.Codlogradouro where pe.Ano == nAno && pe.Numprocesso == nNumero
                       select new ProcessoEndStruct { CodigoLogradouro = pe.Codlogr, NomeLogradouro = l.Endereco, Numero = pe.Numero });
            return Sql.ToList();
        }



    }
}

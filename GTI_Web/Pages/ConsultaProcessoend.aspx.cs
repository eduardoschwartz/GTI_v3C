using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class ConsultaProcessoend : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                String s = Request.QueryString["d"];
                if (s != "gti")
                    Response.Redirect("~/Pages/gtiMenu.aspx");
                try {
                    s = gtiCore.Decrypt(Request.QueryString["x"]);
                } catch  {

                    Response.Redirect("~/Pages/gtiMenu.aspx");
                }

                Processo_bll processo_Class = new Processo_bll("GTIconnection");
                ProcessoStruct _processo=null;
                int _numero = processo_Class.ExtractNumeroProcessoNoDV(s);
                int _ano = processo_Class.ExtractAnoProcesso(s);

                Exception ex = processo_Class.ValidaProcesso(s);
                if (ex != null)
                    Response.Redirect("~/Pages/gtiMenu.aspx");
                else {
                    Processo.Text = s;
                    _processo = processo_Class.Dados_Processo(_ano, _numero);

                    Data_abertura.Text = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy") + " ás " + _processo.Hora;
                    if (_processo.Interno)
                        Requerente.Text = _processo.CentroCustoNome;
                    else
                        Requerente.Text = _processo.NomeCidadao;
                    Assunto.Text = _processo.Assunto;
                }

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Seq"), new DataColumn("Local"), new DataColumn("Data"),
                                new DataColumn("Despacho"), new DataColumn("DataEnvio"), new DataColumn("Situacao")});

                List<TramiteStruct> ListaTramite = processo_Class.DadosTramite((short)_ano, _numero,(int)_processo.CodigoAssunto );

                foreach (var item in ListaTramite) {
                    string _data_entrada = item.DataEntrada == null ? "" : item.DataEntrada;
                    string _hora_entrada = item.HoraEntrada == null ? "" : item.HoraEntrada;
                    string _despacho = item.DespachoNome == null ? "" : item.DespachoNome ;
                    string _data_envio = item.DataEnvio == null ? "" : item.DataEnvio;
                    string _situacao = string.IsNullOrWhiteSpace(item.DataEnvio) ? _despacho : "ENVIADO";

                    dt.Rows.Add(item.Seq.ToString(), item.CentroCustoNome + " - Fone: (16) "  + item.Telefone ,_data_entrada,_despacho,_data_envio,_situacao);
                }

                grdMain.DataSource = dt;
                grdMain.DataBind();


            } else
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }

       
    }
}
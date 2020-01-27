<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gtiMenu.aspx.cs" Inherits="UIWeb.gtiMenu" MasterPageFile="~/Pages/default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />


        <div id="content" style="width: auto">
            <h3>Serviços disponíveis</h3>
            <br />
            <br />
           
            <ul>
                <li><a href="gtiMenu2.aspx?d=gti" style="width: 600px">Consulta e atualização de boletos vencidos para pagamento</a></li>
                <%--<li><a href="wait.aspx?d=gti" style="width: 600px">Consulta e atualização de boletos vencidos para pagamento</a></li>--%>
                <li><a href="SegundaViaIPTU.aspx?d=gti" style="width: 600px;color: #CC0000">Emissão de 2ª via do carnê de IPTU (2020)</a> </li>
                <li><a href="SegundaViaISS.aspx?d=gti" style="width: 600px;color: #CC0000">Emissão de 2ª via do carnê de ISS Fixo/Taxa de Licença (2020)</a> </li>
                <li><a href="SegundaViaVS.aspx?d=gti" style="width: 600px;color: #CC0000">Emissão de 2ª via do carnê de Vigilância Sanitária (2020)</a> </li>
                <li><a href="ConsultaProcesso.aspx?d=gti" style="width: 600px; ">Consulta de Processos</a> </li>
<%--                <li><a href="SegundaViaCIP.aspx?d=gti" style="width: 600px; color: #CC0000">Emissão de 2ª via da contribuição de iluminação pública (CIP) (2019)</a></li>--%>
                <%--<li><a href="cipendereco.aspx?d=gti" style="width: 600px; color: #CC0000">Consultar endereço da contribuição de iluminação pública (CIP) (2019)</a></li>--%>
                <li><a href="detalhe_boleto.aspx?d=gti" style="width: 600px">Impressão dos
                    detalhes de um boleto</a></li>
                <li><a href="certidaoinscricao.aspx?d=gti" style="width: 600px">Comprovante de inscrição e de situação cadastral</a></li>
                <li><a href="../Deca/DECA2018.pdf" style="width: 600px">Download da declaração cadastral (DECA)</a></li>
                <li><a href="readVRExml.aspx?d=gti" style="width: 600px">Importação de arquivos Via Rápida Empresa (VRE)</a></li>
                <li><a href="alvara_funcionamento.aspx?d=gti" style="width: 600px">Renovação de alvará de funcionamento</a></li>
                <li><a href="gticertidao.aspx?d=gti" style="width: 600px">Emissão de certidões / Verificar autenticidade</a></li>
                <li><a href="dadosEmpresa.aspx?d=gti" style="width: 600px">Dados cadastrais de uma empresa</a></li>
                <li><a href="cpv_pagto.aspx?d=gti" style="width: 600px">Impressão de comprovante de pagamento</a></li>
                <li><a href="situacao_pagto.aspx?d=gti" style="width: 600px">Situação dos débitos ref. a ISS Fixo, Taxa de Licença e Vig.Sanitária.</a></li>
                <%--<li><a href="LoginFunc.aspx?d=gti" style="width: 600px">Área restrita do usuário.</a></li>--%>
            </ul>
        </div>

</asp:Content>





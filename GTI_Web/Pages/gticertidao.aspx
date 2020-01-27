<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="gticertidao.aspx.cs" Inherits="GTI_Web.Pages.gticertidao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
     <link href="../css/gti.css" rel="stylesheet" />


        <div id="content" style="width: 600px">
            <h3>Certidões disponíveis</h3>
            <br />
            <br />
           
            <ul>
                <li><a href="certidaoendereco.aspx?d=gti" style="width: 600px">Certidão de endereço atualizado</a></li>
                <li><a href="certidaovalorvenal.aspx?d=gti" style="width: 600px">Certidão de valor venal</a></li>
                <li><a href="certidaoisencao.aspx?d=gti" style="width: 600px">Certidão de isenção de IPTU</a></li>
                <li><a href="certidaodebito.aspx?d=gti" style="width: 600px">Certidão de débito (Código do imóvel ou inscrição municipal)</a></li>
                <li><a href="certidaodebito_doc.aspx?d=gti" style="width: 600px">Certidão de débito (CPF/CNPJ)</a></li>
                <li><a href="certidaoinscricao.aspx?d=gti" style="width: 600px">Comprovante de inscrição e situação cadastral</a></li>
            </ul>
        </div>

</asp:Content>

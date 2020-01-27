<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envioDeca.aspx.cs" Inherits="UIWeb.Pages.envioDeca" MasterPageFile="~/Pages/default.Master" %>

<asp:Content ID="Content" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />



    <div>
    <br />
            
        <br />
        <br />
        Acesso VRE:
        <asp:TextBox ID="txtAcesso" runat="server" MaxLength="8" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btAcesso" runat="server" OnClick="btAcesso_Click" Text="Acessar" />
            <br />
        <br />
    </div>
   
    </asp:Content>
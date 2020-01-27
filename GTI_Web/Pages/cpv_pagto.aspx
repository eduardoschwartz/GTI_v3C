<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="cpv_pagto.aspx.cs" Inherits="GTI_Web.Pages.cpv_pagto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
     <link href="../css/gti.css" rel="stylesheet" />
    <script>

        function formata(campo, mask, evt) {

            if (document.all) { // Internet Explorer 
                key = evt.keyCode;
            }
            else { // Nestcape 
                key = evt.which;
            }

            string = campo.value;
            i = string.length;

            if (i < mask.length) {
                if (mask.charAt(i) == '§') {
                    return (key > 47 && key < 58);
                } else {
                    if (mask.charAt(i) == '!') { return true; }
                    for (c = i; c < mask.length; c++) {
                        if (mask.charAt(c) != '§' && mask.charAt(c) != '!')
                            campo.value = campo.value + mask.charAt(c);
                        else if (mask.charAt(c) == '!') {
                            return true;
                        } else {
                            return (key > 47 && key < 58);
                        }
                    }
                }
            } else return false;
        }
    </script>


        <div style="color: #3a8dcc;">
            
            &nbsp;<br />
            <br />
            Impressão de comprovante de pagamento<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" ForeColor="Black" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" Width="559px">
                <table style="width: 100%;">
                   
                    
                    <tr>
                        <td class="panel" style="width: 159px">&nbsp;&nbsp;
                            <asp:Label ID="lblCod" runat="server" Text="Inscrição Municipal....:"></asp:Label>
                            </td>
                        <td style="width: 391px">
                            
                            <asp:TextBox ID="Codigo" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="6" Width="70px"  onKeyPress="return formata(this, '§§§§§§', event)"></asp:TextBox>
                            &nbsp;

                        
                    </tr>
                    <tr>
                        <td class="panel" style="width: 159px">
                            &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Número do Documento.:"></asp:Label>
                            &nbsp;</td>
                        <td style="width: 391px">
                            <asp:TextBox ID="Documento" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="17" Width="370px" onKeyPress="return formata(this, '§§§§§§§§§§§§§§§§§', event)"></asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>

                  
                </table>
                &nbsp;&nbsp;
                <asp:Label ID="lblmsg" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
                <br />
                <br />
                <table border="0">
                    <tr>
                        <td class="panel">
                            <img height="30" alt="" src="Turing.aspx" width="80" />
                        </td>
                        <td class="panel" style="width: 231px">&nbsp;Digite o conteúdo da imagem
                            <br />
                            &nbsp;
                            <asp:TextBox ID="txtimgcode" runat="server" ViewStateMode="Disabled" Width="126px"></asp:TextBox>
                            &nbsp;</td>
                       <td>
                           <asp:Button ID="Submit" runat="server" OnClick="Submit_Click" Text="Imprimir" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />

        </div>
        <br />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="ConsultaProcesso.aspx.cs" Inherits="GTI_Web.Pages.ConsultaProcesso" %>
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
                        if (mask.charAt(c) != '§' && mask.charAt(c) != '!' )
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
            Consulta de Processos.<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" ForeColor="Black" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" Width="685px">
                <table style="width: 100%;">
                   
                    
                    <tr>
                        <td class="panel" style="width: 170px; text-align: right;"><asp:Label ID="lblCod" runat="server" Text="Nº do processo.:"></asp:Label>
                            </td>
                        <td style="width: 107px">
                            
                            <asp:TextBox ID="Numero" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="7" Width="70px"  onKeyPress="return formata(this, '§§§§§§', event)"></asp:TextBox>
                            &nbsp;

                        <td class="panel" style="width: 153px; text-align: right;"><asp:Label ID="Label1" runat="server" Text="Ano do processo.:"></asp:Label>
                            </td>
                        <td style="width: 391px">
                            
                            <asp:TextBox ID="Ano" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="6" Width="70px"  onKeyPress="return formata(this, '§§§§', event)"></asp:TextBox>
                            &nbsp;

                    </tr>

                  
                </table>
                &nbsp;&nbsp;
                <asp:Label ID="lblMsg" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
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
                           <asp:Button ID="Submit" class="button1" runat="server" OnClick="VerificarButton_Click" Text="Imprimir" Width="91px" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />

        </div>
        <br />
</asp:Content>

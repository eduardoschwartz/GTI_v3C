<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="certidaodebito.aspx.cs" Inherits="GTI_Web.Pages.certidaodebito" %>
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
    
         <br />
             <br />
             Certidão de débito<br />
             <br />
             <table style="width: 624px; height: 62px;">
                 <tr>
                     <td class="auto-style1" style="width: 134px">Código imóvel ou IM..:</td>
                     <td>
                         <asp:TextBox ID="txtIM" runat="server" Width="83px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" onKeyPress="return formata(this, '§§§§§§', event)"></asp:TextBox>
                     </td>
                 </tr>
                 <tr><td></td></tr>
                 <tr>
                     <td style="width: 134px; vertical-align: bottom">
                         <img height="30" alt="" src="Turing.aspx" width="80" />&nbsp;</td>

                     <td class="auto-style1">&nbsp;Digite o conteúdo da imagem                                              
                         <br />
                         <asp:TextBox ID="txtimgcode" runat="server" OnClick="btConsultar_Click" ViewStateMode="Disabled" Width="147px" TabIndex="3" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                         &nbsp; <asp:Button ID="Button1" class="button1" runat="server" Text="Imprimir" OnClick="BtPrint_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <br />
                         <asp:Label ID="Label1" runat="server" Text="Validação da certidão:" ForeColor="Maroon"></asp:Label>
                     </td>
                     </tr>
                 <tr>
                     <td class="auto-style1" style="width: 134px">Código de validação..:</td>
                
                     <td>
                         <asp:TextBox ID="Codigo" runat="server" Width="147px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="20" ></asp:TextBox>
                         &nbsp;
                         <asp:Button ID="ValidarButton" class="button1" runat="server" Text="Validar" OnClick="ValidarButton_Click" />
                     </td>
                 </tr>





             </table>
            <br />
            
             
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>



</asp:Content>

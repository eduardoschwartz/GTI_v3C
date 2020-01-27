<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gtiMenu2.aspx.cs" Inherits="UIWeb.Pages.gtiMenu2" MasterPageFile="~/Pages/default.Master" %>


<asp:Content ID="Content" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
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
        <asp:Label ID="Label4" runat="server" ForeColor="#3a8dcc" Text="Digite a data de pagamento (máximo de 30 dias):" Font-Underline="True"></asp:Label>
            <br />
        <br />
            <asp:TextBox ID="txtVencto" runat="server" MaxLength="10" onKeyPress="return formata(this, '§§/§§/§§§§', event)"></asp:TextBox>
            &nbsp;&nbsp;
                            <asp:Label ID="lblMsg" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
            <br />
            <br />
            <asp:Button class="button" ID="btOK" runat="server" OnClick="btOK_Click" Text="Continuar" />
        </div>
</asp:Content>



<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegundaViaIPTU.aspx.cs" Inherits="UIWeb.SegundaViaIPTU" MasterPageFile="~/Pages/default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />



    <style type="text/css">
        
        .auto-style3 {
            width: 333px;
        }
        .auto-style5 {
            width: 99px;
        }
    </style>

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
            &nbsp;<br />
            
            Impressão do carnê de IPTU - 2020<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" ForeColor="Black" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" Width="603px">
                <table style="width: 100%;">


                    <tr>
                        <td class="panel">&nbsp;&nbsp;
                            <asp:Label ID="lblCod" runat="server" Text="Código do imóvel..:"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtCod" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="6" Width="70px"  onKeyPress="return formata(this, '§§§§§§', event)"></asp:TextBox>
                            &nbsp; </td>

                    </tr>
                    <tr>
                        <td class="panel">&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Inscrição Cadastral..:"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtIC" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="25" Width="197px" onKeyPress="return formata(this, '§.§§.§§§§.§§§§§.§§.§§.§§§', event)"></asp:TextBox>
                        </td>

                    </tr>


                </table>
                <br />
                <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                <br />
                <table border="0">
                    <tr>
                        <td class="auto-style5">
                            <img height="30" alt="" src="Turing.aspx" width="80" />
                            &nbsp;
                        </td>
                        <td class="panel">&nbsp;Digite o conteúdo da imagem
                            <br />
                            &nbsp;<asp:TextBox ID="txtimgcode" runat="server" ViewStateMode="Disabled" Width="147px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;      <asp:Button ID="btPrint" class="button1" runat="server" OnClick="btPrint_Click" Text="Imprimir" Width="100px" />
                            <br />
                        </td>
                      
                    </tr>
                </table>
            </asp:Panel>
            <br />

        </div>
        <br />
   
</asp:Content>
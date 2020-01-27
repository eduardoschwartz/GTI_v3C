<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detalhe_boleto.aspx.cs" Inherits="UIWeb.Pages.detalhe_boleto" MasterPageFile="~/Pages/default.Master" %>
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

    <style type="text/css">
        
        .auto-style6 {
            color: #FF0000;
            font-size: small;
        }
        .auto-style7 {
            color: #000000;
            font-size: small;
        }
    </style>
        <div style="color: #3a8dcc;">
            <br />
            &nbsp;<br  />
             Imprimir detalhes de um boleto<br />
            <br />
            <asp:Label ID="Label11" runat="server" Text="Digite o nº do documento..:"  ></asp:Label>
            &nbsp;
            <asp:TextBox ID="txtCod" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="17" Width="232px" OnTextChanged="txtCod_TextChanged" onKeyPress="return formata(this, '§§§§§§§§§§§§§§§§§', event)" ></asp:TextBox>
            <br />
            
            <br />
                        <asp:RadioButton ID="optCPF" runat="server" AutoPostBack="True" Checked="True" GroupName="optDoc" OnCheckedChanged="optCPF_CheckedChanged" Text="CPF"  />
                        &nbsp;
                        <asp:RadioButton ID="optCNPJ" runat="server" AutoPostBack="True" GroupName="optDoc" OnCheckedChanged="optCNPJ_CheckedChanged" Text="CNPJ"  />
                       
                         
                            &nbsp;
                       
                         
                            <asp:TextBox ID="txtCPF" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="14" Width="166px" TabIndex="1"  onKeyPress="return formata(this, '§§§.§§§.§§§-§§', event)"></asp:TextBox>
                            
                            <asp:TextBox ID="txtCNPJ" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="18" onKeyPress="return formata(this, '§§.§§§.§§§/§§§§-§§', event)" TabIndex="1" Visible="False" Width="166px"></asp:TextBox>
            <br />
            <span class="auto-style7">(CPF/CNPJ conforme informado no boleto)<br />
            </span><span class="auto-style6"><br />
            </span>
            <asp:Button ID="btConsultar" class="button1" runat="server" OnClick="btConsultar_Click" Text="Imprimir" />
&nbsp;
            <asp:Label ID="lblMsg" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label>
        </div>
   
</asp:Content>
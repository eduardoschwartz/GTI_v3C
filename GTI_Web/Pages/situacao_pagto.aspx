<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="situacao_pagto.aspx.cs" Inherits="GTI_Web.Pages.situacao_pagto" %>
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
            Situação dos débitos referentes a ISS Fixo, Taxa de Licença e Taxa de Vigilância Sanitária.<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" ForeColor="Black" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" Width="685px">
                <table style="width: 100%;">
                   
                    
                    <tr>
                        <td class="panel" style="width: 115px; text-align: right;"><asp:Label ID="lblCod" runat="server" Text="Inscrição Municipal.:"></asp:Label>
                            </td>
                        <td style="width: 391px">
                            
                            <asp:TextBox ID="Codigo" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="6" Width="70px"  onKeyPress="return formata(this, '§§§§§§', event)"></asp:TextBox>
                            &nbsp;

                        
                    </tr>
                    <tr>
                        <td class="panel" style="height: 51px; width: 115px;">&nbsp;
                        <asp:RadioButton ID="optCPF" runat="server" AutoPostBack="True" Checked="True" GroupName="optDoc" OnCheckedChanged="optCPF_CheckedChanged" Text="CPF" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="optCNPJ" runat="server" AutoPostBack="True" GroupName="optDoc" OnCheckedChanged="optCNPJ_CheckedChanged" Text="CNPJ" />
                        </td> <td class="panel" style="height: 51px">&nbsp;&nbsp;
                         <asp:Label ID="Label3" runat="server" Text="CPF/CNPJ:"></asp:Label>
                            &nbsp;
                        &nbsp;
                            <asp:TextBox ID="txtCPF" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="14" Width="158px" TabIndex="1"  onKeyPress="return formata(this, '§§§.§§§.§§§-§§', event)" OnTextChanged="txtCPF_TextChanged"></asp:TextBox>
                            
                            <asp:TextBox ID="txtCNPJ" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="18" onKeyPress="return formata(this, '§§.§§§.§§§/§§§§-§§', event)" TabIndex="1" Visible="False" Width="166px" OnTextChanged="txtCNPJ_TextChanged"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                         
                        </td></tr>

                  
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

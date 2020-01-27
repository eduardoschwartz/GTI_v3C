<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="certidaodebito_doc.aspx.cs" Inherits="GTI_Web.Pages.certidaodebito_doc" %>
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
             <span style="text-decoration: underline">Certidão de Débito - Informe o CPF/CNPJ</span><br />
             <br />
             <%--<table style="width: 624px; height: 62px;">--%>
                 <tr><td class="panel" style="height: 51px">&nbsp;
                        <asp:RadioButton ID="optCPF" runat="server" AutoPostBack="True" Checked="True" GroupName="optDoc" OnCheckedChanged="optCPF_CheckedChanged" Text="CPF" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="optCNPJ" runat="server" AutoPostBack="True" GroupName="optDoc" OnCheckedChanged="optCNPJ_CheckedChanged" Text="CNPJ" />
                        </td> <td class="panel" style="height: 51px">&nbsp;&nbsp;
                         <asp:Label ID="Label3" runat="server" Text="CPF/CNPJ:"></asp:Label>
                            &nbsp;
                        &nbsp;
                            <asp:TextBox ID="txtCPF" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="14" Width="166px" TabIndex="1"  onKeyPress="return formata(this, '§§§.§§§.§§§-§§', event)"></asp:TextBox>
                            
                            <asp:TextBox ID="txtCNPJ" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="18" onKeyPress="return formata(this, '§§.§§§.§§§/§§§§-§§', event)" TabIndex="1" Visible="False" Width="166px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;<br />
             <br />
&nbsp;</td></tr>
             <tr><td style="width: 134px; vertical-align: bottom"><img height="30" alt="" src="Turing.aspx" width="80" />&nbsp;</td>

                     <td class="panel">&nbsp;Digite o conteúdo da imagem                                              
                         <asp:TextBox ID="txtimgcode" runat="server" OnClick="btConsultar_Click" ViewStateMode="Disabled" Width="147px" TabIndex="3" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                         &nbsp; <asp:Button ID="Button1" class="button1" runat="server" Text="Imprimir" OnClick="btPrint_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td>
                         <br />
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
                         <br />
                         <br />
                         <br />
                         <br />
                     </td>
                 </tr>
                





             </table>
            <br />
            
             
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>



</asp:Content>

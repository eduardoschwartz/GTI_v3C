<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dadosEmpresa.aspx.cs" Inherits="UIWeb.Pages.dadosEmpresa" MasterPageFile="~/Pages/default.Master" %>

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
    
         <br />
            <br />
            Dados Cadastrais de Empresa<br />
            <br />
            <table style="width: 473px;">
                <tr>
                    <td  style="width: 95px">Inscrição Municipal..:</td>
                    <td>
                <asp:TextBox ID="txtIM" runat="server" Width="83px"  BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" onKeyPress="return formata(this, '§§§§§§', event)" style="margin-left: 1.6em"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                   <td class="panel" style="height: 51px">&nbsp;
                        <asp:RadioButton ID="optCPF" runat="server" AutoPostBack="True" Checked="True" GroupName="optDoc" OnCheckedChanged="optCPF_CheckedChanged" Text="CPF" />
                        &nbsp;&nbsp;
                        <asp:RadioButton ID="optCNPJ" runat="server" AutoPostBack="True" GroupName="optDoc" OnCheckedChanged="optCNPJ_CheckedChanged" Text="CNPJ" />
                        </td> <td class="panel" style="height: 51px">&nbsp;&nbsp;
                         <asp:Label ID="Label3" runat="server" Text="CPF/CNPJ:"></asp:Label>
                            &nbsp;
                        &nbsp;
                            <asp:TextBox ID="txtCPF" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="14" Width="166px" TabIndex="1"  onKeyPress="return formata(this, '§§§.§§§.§§§-§§', event)" OnTextChanged="txtCPF_TextChanged"></asp:TextBox>
                            
                            <asp:TextBox ID="txtCNPJ" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="18" onKeyPress="return formata(this, '§§.§§§.§§§/§§§§-§§', event)" TabIndex="1" Visible="False" Width="166px" OnTextChanged="txtCNPJ_TextChanged"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                         
                        </td>
                </tr>
                <tr>
                    <td  style="width: 95px">&nbsp;</td>
                    <td>
                <asp:Button ID="btAcesso" class="button1" runat="server" Text="Consultar" OnClick="btAcesso_Click" />
                    &nbsp;<asp:Button ID="btPrint" class="button1" runat="server" Text="Imprimir" OnClick="btPrint_Click" />
                    </td>
                </tr>
            </table>
            <br />
            
             
         <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />

     </div>
        <br />
        <br />
        <asp:Table ID="Tbl" runat="server" Width="610px" BorderStyle="Double" Height="19px" BorderColor="#3a8dcc" CaptionAlign="Left" Font-Bold="False">
            <asp:TableRow Width="550px" BorderStyle="Solid" BorderWidth="1px">
                <asp:TableCell Width="30%">Inscrição Municipal</asp:TableCell>
                <asp:TableCell runat="server" ID="IM" Width="70%" ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Razão Social</asp:TableCell>
                <asp:TableCell ID="RAZAOSOCIAL" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">CNPJ/CPF</asp:TableCell>
                <asp:TableCell ID="CNPJ" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Inscrição Estadual</asp:TableCell>
                <asp:TableCell ID="IE" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Endereço</asp:TableCell>
                <asp:TableCell ID="ENDERECO" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Data de Abertura</asp:TableCell>
                <asp:TableCell ID="DATAABERTURA" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">Data de Encerramento</asp:TableCell>
                <asp:TableCell ID="DATAENCERRAMENTO" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Situação</asp:TableCell>
                <asp:TableCell ID="SITUACAO" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Email</asp:TableCell>
                <asp:TableCell ID="EMAIL" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Telefone</asp:TableCell>
                <asp:TableCell ID="TELEFONE" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Regime de ISS</asp:TableCell>
                <asp:TableCell ID="REGIMEISS" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Vigilância Sanitária</asp:TableCell>
                <asp:TableCell ID="VIGSANIT" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Taxa de Licença</asp:TableCell>
                <asp:TableCell ID="TAXALICENCA" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Micro Emp.Individual</asp:TableCell>
                <asp:TableCell ID="MEI" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Área</asp:TableCell>
                <asp:TableCell ID="AREA" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Proprietário(s)</asp:TableCell>
                <asp:TableCell ID="PROPRIETARIO" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
             <asp:TableRow runat="server">
                <asp:TableCell runat="server">Atividade(s)</asp:TableCell>
                <asp:TableCell ID="CNAE" runat="server"  ForeColor="#3a8dcc"></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    
</asp:Content>
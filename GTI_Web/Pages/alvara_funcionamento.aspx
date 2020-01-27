<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="alvara_funcionamento.aspx.cs" Inherits="GTI_Web.Pages.alvara_funcionamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />


        <div style="color: #3a8dcc;">
            
            &nbsp;<br />
            <br />
            Emissão de alvará de funcionamento<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" ForeColor="Black" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" Width="675px">
                <table style="width: 100%;">
                   
                    
                    <tr>
                        <td class="panel">&nbsp;&nbsp;
                            <asp:Label ID="lblCod" runat="server" Text="Inscrição Municipal.:"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtCod" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="6" Width="70px" ></asp:TextBox>
                            &nbsp; </td>
                    </tr>
                    <tr>
                        <td class="panel">
                            <br />
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
                        </td>

                    </tr>

                  
                </table>
                <br />
                <table border="0">
                    <tr>
                        <td style="width: 134px; vertical-align: bottom">
                         <img height="30" alt="" src="Turing.aspx" width="80" />&nbsp;</td>

                     <td class="panel">
                         <asp:Label ID="Label2" runat="server" Text="Digite o conteúdo da imagem:"></asp:Label>
                         <br />
                         <asp:TextBox ID="txtimgcode" runat="server" OnClick="btConsultar_Click" ViewStateMode="Disabled" Width="147px" TabIndex="3" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                          
                     </td>
                        <td>
                            <asp:Button ID="Button1" class="button1" runat="server" Text="Imprimir" OnClick="btPrint_Click" Width="103px" />
                        </td>
                    </tr>
                    <tr>
                     <td>
                         <br />
                         <asp:Label ID="Label1" runat="server" Text="Validação da certidão:" ForeColor="Maroon"></asp:Label>
                     </td>
                     </tr>
                 <tr>
                     <td class="panel" style="width: 134px"><asp:Label ID="Label4" runat="server" Text="Código de validação:"></asp:Label></td>
                
                     <td style="width: 189px">
                         <asp:TextBox ID="Codigo" runat="server" Width="147px" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="20" ></asp:TextBox>
                         
                         
                     </td>
                     <td>
<asp:Button ID="ValidarButton" class="button1" runat="server" Text="Validar" OnClick="ValidarButton_Click" Width="104px" />
                     </td>
                 </tr>
                </table>
            </asp:Panel>
            <br />

        </div>
        <br />
    
</asp:Content>

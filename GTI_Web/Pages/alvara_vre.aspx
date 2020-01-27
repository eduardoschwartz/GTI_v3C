<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="alvara_vre.aspx.cs" Inherits="UIWeb.alvara_vre"  MasterPageFile="~/Pages/default.Master"  %>

<asp:Content ID="Content" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />


        <div style="color: #3a8dcc;">
            
            &nbsp;<br />
            <br />
            Emissão de alvará de funcionamento para empresas cadastradas pelo Via Rápida Empresa<br />
            <br />
            <asp:Panel ID="Panel2" runat="server" ForeColor="Black" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" Width="675px">
                <table style="width: 100%;">
                   
                    
                    <tr>
                        <td class="panel">&nbsp;&nbsp;
                            <asp:Label ID="lblCod" runat="server" Text="Inscrição Municipal.:"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtCod" runat="server" BorderColor="#3399FF" BorderStyle="Solid" BorderWidth="1px" MaxLength="6" Width="70px" ></asp:TextBox>
                            &nbsp; </td>
                        <td class="panel">
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>

                  
                </table>
                <br />
                <table border="0">
                    <tr>
                        <td class="panel">
                            <img height="30" alt="" src="Turing.aspx" width="80" />
                        </td>
                        <td class="panel">&nbsp;Digite o conteúdo da imagem
                            <br />
                            <asp:TextBox ID="txtimgcode" runat="server" ViewStateMode="Disabled" Width="147px"></asp:TextBox>
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
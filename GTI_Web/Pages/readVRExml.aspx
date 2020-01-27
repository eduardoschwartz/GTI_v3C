<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="readVRExml.aspx.cs" Inherits="UIWeb.Pages.readVRExml" MasterPageFile="~/Pages/default.Master"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
    <link href="../css/gti.css" rel="stylesheet" />



        <div style="color: #3a8dcc;">
            
            &nbsp;<br />
            <br />
            Importação de arquivos do Via Rápida Empresa - VRE<br />
            <br />
            <br />
            <asp:Label runat="server" ID="lblArquivo"  Text="Escolha um arquivo para enviar..:" Font-Size="Small" ForeColor="Maroon"></asp:Label>
            <asp:FileUpload class="bu" ID="FileUpload1" style=" margin-left:30px;" runat="server" /> 
            &nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label runat="server" ID="lblArquivo0"  Text="Tipo de arquivo selecionado..:" Font-Size="Small" ForeColor="Maroon"></asp:Label>
            &nbsp;
            <asp:DropDownList ID="TipoArquivoList" runat="server" Height="16px" Width="200px">
                <asp:ListItem Value="1">VRE - Antigo</asp:ListItem>
                <asp:ListItem Value="2">REDESIM - Viabilidade</asp:ListItem>
                <asp:ListItem Value="3">REDESIM - Licenciamento</asp:ListItem>
            </asp:DropDownList>
            <br />

        <br /> <asp:button CssClass="button1" id="btEnviar" runat="server" text="Importar" OnClick="btEnviar_Click" Width="100px" /> &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" >
                <Columns>
                    <asp:BoundField DataField="Seq" HeaderText="Id/Protocolo">
                    <HeaderStyle ForeColor="Maroon" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nome" HeaderText="Razão Social">
                    <HeaderStyle ForeColor="Maroon" HorizontalAlign="Left" />
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="doc" HeaderText="Cpf/Cnpj">
                    <HeaderStyle ForeColor="Maroon" HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Sit" HeaderText="Situação">
                    <HeaderStyle ForeColor="Maroon" HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>

            </asp:GridView>
            <br />
        <asp:Label ID="Statuslbl" runat="server" ForeColor="Red" />
            <br />
            <br />
        </div>
        <br />
    
    </asp:Content>
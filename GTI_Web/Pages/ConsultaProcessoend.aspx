<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/default.Master" AutoEventWireup="true" CodeBehind="ConsultaProcessoend.aspx.cs" Inherits="GTI_Web.Pages.ConsultaProcessoend" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MenuContentPlaceHolder" runat="server">
     <link href="../css/gti.css" rel="stylesheet" />
     <style type="text/css">
        
      
       
        .auto-style7 {
            font-size: 8pt;
            font: 400 10px/1.5 Arial,Verdana, sans-serif, Helvetica;
            color: #3a8dcc;
            width: 947px;
           height:400px;
            overflow: auto;
             margin-right: 0em;
         }
      
    </style>

        <div style="color: #3a8dcc;">
            <br />
            &nbsp;<br />
            
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
            Consulta de Processos<br />
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Font-Size="Small" Text="Nº do Processo:"></asp:Label>
            <asp:Label ID="Processo" runat="server" Font-Size="Small" ForeColor="#990000" Text="00000-0/0000"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Font-Size="Small" Text="Requerente: "></asp:Label>
            <asp:Label ID="Requerente" runat="server" Font-Size="Small" ForeColor="Maroon" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Font-Size="Small" Text="Data de Abertura: "></asp:Label>
            <asp:Label ID="Data_abertura" runat="server" Font-Size="Small" ForeColor="Maroon" Text="00/00/0000"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Font-Size="Small" Text="Assunto: "></asp:Label>
            <asp:Label ID="Assunto" runat="server" Font-Size="Small" ForeColor="Maroon" Text="..."></asp:Label>
            <br />
            <br />
           
            <div class="auto-style7" style="color: #3a8dcc; " >
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                    <ContentTemplate>
                        <div style="text-align: right">
                            <asp:GridView ID="grdMain" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" TabIndex="7" Width="859px">
                                <Columns>
                                    <asp:BoundField DataField="Seq" HeaderStyle-HorizontalAlign="Center" HeaderText="Seq" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small" ItemStyle-ForeColor="#3A8DCC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30">
                                    <HeaderStyle Font-Bold="false" Font-Size="Small" HorizontalAlign="Center" />
                                    <ItemStyle Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Local" HeaderText="Local" HtmlEncode="false" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small" ItemStyle-ForeColor="#3A8DCC" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150">
                                    <HeaderStyle Font-Bold="false" Font-Size="Small" HorizontalAlign="Left" />
                                    <ItemStyle Width="180px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Data" HeaderStyle-HorizontalAlign="Center" HeaderText="Data de Recebimento" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small" ItemStyle-ForeColor="#3A8DCC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30">
                                    <HeaderStyle Font-Bold="false" Font-Size="Small" HorizontalAlign="Center" />
                                    <ItemStyle Width="40px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Despacho" HeaderStyle-HorizontalAlign="Left" HeaderText="Despacho" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small" ItemStyle-ForeColor="#3A8DCC" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70">
                                    <HeaderStyle Font-Bold="false" Font-Size="Small" HorizontalAlign="Left" Width="120px" />
                                    <ItemStyle Width="120px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DataEnvio" HeaderStyle-HorizontalAlign="Center" HeaderText="Data de Envio" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small" ItemStyle-ForeColor="#3A8DCC" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="30">
                                    <HeaderStyle HorizontalAlign="Center" Font-Bold="False" />
                                    <ItemStyle Font-Names="Arial" Font-Size="X-Small" ForeColor="#3A8DCC" HorizontalAlign="Center" Width="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Situacao" HeaderStyle-HorizontalAlign="Left" HeaderText="Situação" ItemStyle-Font-Names="Arial" ItemStyle-Font-Size="X-Small" ItemStyle-ForeColor="#3A8DCC" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="70">
                                    <HeaderStyle Font-Bold="false" Font-Size="Small" HorizontalAlign="Left" Width="70px" />
                                    <ItemStyle Width="120px" />
                                    </asp:BoundField>

                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Size="Small" NavigateUrl="~/Pages/ConsultaProcesso.aspx?d=gti">Consultar outro processo</asp:HyperLink>

            <br />
        </div>
        <br />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VerConsultas.aspx.cs" Inherits="VerConsultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </p>
    <p>
        <br />
    </p>
    <p>
        Selecione uma data para checar as consultas marcadas:</p>
    <p>
        <asp:TextBox ID="txtData" runat="server" TextMode="Date" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#CCFFCC" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </p>
</asp:Content>


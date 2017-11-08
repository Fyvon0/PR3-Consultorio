<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="VerConsultasSec.aspx.cs" Inherits="VerConsultasSec" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </p>
    <p>
&nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem Value="0">Visão Diária</asp:ListItem>
            <asp:ListItem Value="1">Visão Geral</asp:ListItem>
        </asp:RadioButtonList>
    </p>
    <p>
        <asp:TextBox ID="txtData" runat="server" TextMode="Date" Visible="False" AutoPostBack="True" OnTextChanged="txtData_TextChanged"></asp:TextBox>
    </p>
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
    </asp:Content>


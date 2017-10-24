<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <br />
    <table style="display: block; margin: auto; width: 22%">
        <tr>
            <td style="width: 85px">Login:</td>
            <td style="width: 321px">
                <asp:TextBox ID="txtLogin" runat="server" MaxLength="20" Width="156px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 85px">Senha:</td>
            <td style="width: 321px">
                <asp:TextBox ID="txtSenha" runat="server" MaxLength="30" Width="156px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 85px">
                <asp:Button ID="btnLogar" runat="server" Text="Logar" OnClick="btnLogar_Click" />
            </td>
            <td style="width: 321px">
                <asp:Label ID="lblMensagem" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Secretaria.aspx.cs" Inherits="Secretaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
        <Items>
            <asp:MenuItem Text="Cadastrar Médico" Value="1" NavigateUrl="~/CadastroMedico.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Cadastrar Especialidade Médica" Value="2"></asp:MenuItem>
            <asp:MenuItem Text="Cadastrar Secretária" Value="3"></asp:MenuItem>
            <asp:MenuItem Text="Agendar Consulta" Value="4"></asp:MenuItem>
        </Items>
        <StaticMenuItemStyle HorizontalPadding="10px" />
    </asp:Menu>
    <table cellspacing="1" style="border: 1px solid #cde2a7" id="tablePaciente">
        <tr>
            <td style="width: 277px; height: 23px;">Nome:
                <asp:Label ID="lblNome" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">Email:
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">Celular:
                <asp:Label ID="lblCel" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">
                <asp:Button ID="btnDeslogar" runat="server" OnClick="btnDeslogar_Click" Text="Deslogar" />
            </td>
        </tr>
    </table>
</asp:Content>


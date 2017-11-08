<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastrarEspecialidade.aspx.cs" Inherits="CadastrarEspecialidade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </p>
    <p>
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Verificacao" ShowMessageBox="False" CssClass="alert-warning" />
    <p>
        Especialidade:
        <asp:TextBox ID="txtNomeEspec" runat="server" MaxLength="50" Width="212px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomeEspec" ErrorMessage="Favor inserir o nome da especialidade" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
        </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnCadastrarEspecialidade" runat="server" OnClick="btnCadastrarEspecialidade_Click" Text="Cadastrar" ValidationGroup="Verificacao" />
    </p>
</asp:Content>


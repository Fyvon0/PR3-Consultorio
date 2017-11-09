<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastrarSecretaria.aspx.cs" Inherits="CadastrarSecretaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
<p>
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Verificacao" ShowMessageBox="False" CssClass="alert-warning" />
    <p>
        Nome:
        <asp:TextBox ID="txtNomeSec" runat="server" MaxLength="50" Width="212px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNomeSec" ErrorMessage="Favor inserir um nome" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        Email:
        <asp:TextBox ID="txtEmailSec" runat="server" TextMode="Email" MaxLength="50" Width="212px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailSec" ErrorMessage="Favor inserir o email da secretaria" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
        &nbsp;&nbsp;
    </p>
    <p>
        Celular:
        <asp:TextBox ID="txtCelSec" runat="server" MaxLength="14" ToolTip="Telefone móvel no formato (XX)XXXXX-XXXX" Width="203px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCelSec" ErrorMessage="Favor inserir o celular da secretaria" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
        &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCelSec" Display="Dynamic" ErrorMessage="Inserir um formato válido de celular: (XX)XXXXX-XXXX" ValidationExpression="^\([1-9]{2}\)(9[1-9])[0-9]{3}\-[0-9]{4}$" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RegularExpressionValidator>
        &nbsp;&nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Login:&nbsp;
        <asp:TextBox ID="txtLoginSec" runat="server" MaxLength="20" Width="211px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLoginSec" Display="Dynamic" ErrorMessage="Favor inserir um nome de login" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Senha:&nbsp;
        <asp:TextBox ID="txtSenhaSec" runat="server" MaxLength="30" TextMode="Password" Width="184px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSenhaSec" Display="Dynamic" ErrorMessage="Favor inserir uma senha" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
    </p>
    <p>
        <asp:Button ID="btnCadastrarSecretaria" runat="server" Text="Cadastrar" OnClick="btnCadastrarSecretaria_Click" ValidationGroup="Verificacao" />
    </p>
</asp:Content>


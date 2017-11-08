<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastroPaciente.aspx.cs" Inherits="CadastroCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Verificacao" ShowMessageBox="False" CssClass="alert-warning" />
    <p>
        Nome:
        <asp:TextBox ID="txtNomePac" runat="server" MaxLength="50" Width="212px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomePac" ErrorMessage="Favor inserir o nome do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Endereço:
        <asp:TextBox ID="txtEnderecoPac" runat="server" MaxLength="100" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEnderecoPac" ErrorMessage="Favor inserir o endereço do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
    &nbsp;</p>
<p>
        Data nascimento:&nbsp;
        <asp:TextBox ID="txtDataNascPac" runat="server" TextMode="Date" Width="137px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDataNascPac" ErrorMessage="Favor inserir a data de nascimento do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:
        <asp:TextBox ID="txtEmailPac" runat="server" TextMode="Email" MaxLength="50" Width="186px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmailPac" ErrorMessage="Favor inserir o email do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
    &nbsp;&nbsp;
    </p>
<p>
        Telefone residencial:
        <asp:TextBox ID="txtTelPac" runat="server" MaxLength="13" ToolTip="Telefone residencial no formato (XX)XXXX-XXXX"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelPac" ErrorMessage="Favor inserir o telefone do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTelPac" Display="Dynamic" ErrorMessage="Insira um formato válido de telefone (XX)XXXX-XXXX" ValidationExpression="^\([1-9]{2}\)([2-8])[0-9]{3}\-[0-9]{4}$" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RegularExpressionValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Celular:
        <asp:TextBox ID="txtCelPac" runat="server" MaxLength="14" ToolTip="Telefone móvel no formato (XX)XXXXX-XXXX"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCelPac" ErrorMessage="Favor inserir o celular do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCelPac" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ValidationExpression="^\([1-9]{2}\)(9[1-9])[0-9]{3}\-[0-9]{4}$" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RegularExpressionValidator>
    </p>
    <p>
        Login:&nbsp;
        <asp:TextBox ID="txtLoginPac" runat="server" MaxLength="20" Width="211px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLoginPac" ErrorMessage="Inserir um nome de login" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Senha:&nbsp;
        <asp:TextBox ID="txtSenhaPac" runat="server" MaxLength="30" TextMode="Password" Width="159px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSenhaPac" ErrorMessage="Inserir uma senha" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
    </p>
    <p>
        Foto:
        <asp:FileUpload ID="fupFoto" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="fupFoto" ErrorMessage="Inserir uma foto" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnCadastrarPac" runat="server" Text="Cadastrar" OnClick="btnCadastrarPac_Click" ValidationGroup="Verificacao" />
    </p>
</asp:Content>


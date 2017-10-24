<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CadastroMedico.aspx.cs" Inherits="CadastroMedico" %>

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
        Nome:
        <asp:TextBox ID="txtNomeMed" runat="server" MaxLength="50" Width="212px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomeMed" ErrorMessage="Favor inserir o nome do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Data nascimento:&nbsp;
        <asp:TextBox ID="txtDataNascMed" runat="server" TextMode="Date" Width="137px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDataNascMed" ErrorMessage="Favor inserir a data de nascimento do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p>
        Email:
        <asp:TextBox ID="txtEmailMed" runat="server" TextMode="Email" MaxLength="50" Width="212px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmailMed" ErrorMessage="Favor inserir o email do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Telefone residencial:
        <asp:TextBox ID="txtTelMed" runat="server" MaxLength="13" ToolTip="Telefone residencial no formato (XX)XXXX-XXXX"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelMed" ErrorMessage="Favor inserir o telefone do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p>
        Celular:
        <asp:TextBox ID="txtCelMed" runat="server" MaxLength="14" ToolTip="Telefone móvel no formato (XX)XXXXX-XXXX" Width="199px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCelMed" ErrorMessage="Favor inserir o celular do paciente" Display="Dynamic" ValidationGroup="Verificacao"><img src="Resources/erro.png"/></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Especialidade:
        <asp:DropDownList ID="ddlEspecialidade" runat="server" DataSourceID="dsEspecialidade" DataTextField="nome" DataValueField="idEspecialidade">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlEspecialidade" ErrorMessage="Por favor escolher uma especialidade" ValidationGroup="Verificacao">  <img src="Resources/erro.png" /></asp:RequiredFieldValidator>
    </p>
    <p>
        Login:&nbsp;
        <asp:TextBox ID="txtLoginMedico" runat="server" MaxLength="20" Width="211px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtLoginMedico" Display="Dynamic" ErrorMessage="Favor inserir um nome de login" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Senha:&nbsp;
        <asp:TextBox ID="txtSenhaMedico" runat="server" MaxLength="30" TextMode="Password" Width="159px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtSenhaMedico" Display="Dynamic" ErrorMessage="Favor inserir uma senha" ValidationGroup="Verificacao"><img src="Resources/erro.png" /></asp:RequiredFieldValidator>
    </p>
    <p>
        Foto:
        <asp:FileUpload ID="fupFoto" runat="server" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnCadastrarPac" runat="server" Text="Cadastrar" ValidationGroup="Verificacao" OnClick="btnCadastrarPac_Click" />
        <asp:SqlDataSource ID="dsEspecialidade" runat="server" ConnectionString="<%$ ConnectionStrings:PRII16164ConnectionString %>" SelectCommand="SELECT [idEspecialidade], [nome] FROM [pp3_Especialidade]"></asp:SqlDataSource>
    </p>
</asp:Content>


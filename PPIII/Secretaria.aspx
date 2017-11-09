<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Secretaria.aspx.cs" Inherits="Secretaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        Seja bem vindo(a),
    </p>
    <p>
        &nbsp;</p>
    <p>
        Escolha uma operação:</p>
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="Cadastrar Médico" Value="1" NavigateUrl="~/CadastroMedico.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Cadastrar Especialidade Médica" Value="2" NavigateUrl="~/CadastrarEspecialidade.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Cadastrar Secretária" Value="3" NavigateUrl="~/CadastrarSecretaria.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Ver Consultas" Value="Ver Consultas" NavigateUrl="~/VerConsultasSec.aspx"></asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/relatoriocerto.aspx" Text="Relatórios de Medição" Value="Relatórios de Medição"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>


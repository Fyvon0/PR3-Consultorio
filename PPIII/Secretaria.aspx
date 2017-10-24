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
            <asp:MenuItem Text="Cadastrar Especialidade Médica" Value="2"></asp:MenuItem>
            <asp:MenuItem Text="Cadastrar Secretária" Value="3"></asp:MenuItem>
            <asp:MenuItem Text="Agendar Consulta" Value="4"></asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>


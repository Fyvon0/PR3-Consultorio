<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PacienteMarcarConsulta.aspx.cs" Inherits="PacienteMarcarConsulta" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        Especialidade:
        <asp:DropDownList ID="ddlEspecialidade" runat="server" DataSourceID="EspecialidadeDS" DataTextField="nome" DataValueField="idEspecialidade" AutoPostBack="True">
        </asp:DropDownList>
&nbsp;Médico:
        <asp:DropDownList ID="ddlMedico" runat="server" DataSourceID="MedicoDS" DataTextField="nome" DataValueField="idMedico">
        </asp:DropDownList>
    </p>
    <p>
        Data:
        <asp:TextBox ID="txtData" runat="server" TextMode="Date"></asp:TextBox>
&nbsp; Horário:
        <asp:TextBox ID="txtHorario" runat="server" TextMode="Time"></asp:TextBox>
        &nbsp; Duração:
        <asp:DropDownList ID="ddlDuracao" runat="server">
            <asp:ListItem Value="30">0h30min</asp:ListItem>
            <asp:ListItem Value="60">1h00m</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="btnMarcarConsulta" runat="server" OnClick="btnMarcarConsulta_Click" Text="Marcar Consulta" />
&nbsp;
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </p>
    <p>
        <asp:SqlDataSource ID="MedicoDS" runat="server" ConnectionString="<%$ ConnectionStrings:PRII16164ConnectionString %>" SelectCommand="SELECT [idMedico], [nome] FROM [pp3_Medico] WHERE ([idEspecialidade] = @idEspecialidade)">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlEspecialidade" Name="idEspecialidade" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="EspecialidadeDS" runat="server" ConnectionString="<%$ ConnectionStrings:PRII16164ConnectionString %>" SelectCommand="SELECT [idEspecialidade], [nome] FROM [pp3_Especialidade]"></asp:SqlDataSource>
    </p>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MedicoRelatarConsulta.aspx.cs" Inherits="MedicoRelatarConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Panel ID="pnlMensagem" runat="server" Visible="False">
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlEscolha" runat="server">
        Qual consulta deseja relatar:&nbsp;
        <asp:DropDownList ID="ddlConsultas" runat="server" DataSourceID="ConsultasHojeDS" DataTextField="consulta" DataValueField="idConsulta">
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="btnEscolher" runat="server" OnClick="btnEscolher_Click" Text="Confirmar" />
        <asp:SqlDataSource ID="ConsultasHojeDS" runat="server" ConnectionString="<%$ ConnectionStrings:PRII16164ConnectionString %>" SelectCommand="SELECT [idConsulta], [consulta] FROM [pp3_v_ConsultasHoje]"></asp:SqlDataSource>
    </asp:Panel>
    <asp:Panel ID="pnlConsulta" runat="server" Visible="False">
        Consulta escolhida:<asp:Label ID="lblConsulta" runat="server"></asp:Label>
        <br />
        <table cellspacing="1" style="width: 100%; border: 1px solid #cde2a7">
            <tr>
                <td>Sintomas:</td>
                <td>Exames:</td>
                <td>Diagnóstico:</td>
                <td>Medicação:</td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtSintomas" runat="server" Height="88px" TextMode="MultiLine" Width="249px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtExames" runat="server" Height="88px" TextMode="MultiLine" Width="249px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtDiagnostico" runat="server" Height="88px" TextMode="MultiLine" Width="249px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtMedicacao" runat="server" Height="88px" TextMode="MultiLine" Width="249px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_Click" Text="Confirmar" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
    </asp:Panel>
    <p>
        <br />
    </p>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PacienteCancelarConsulta.aspx.cs" Inherits="PacienteCancelarConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
	<asp:Panel ID="pnlConsulta" runat="server">
		<p>
			Qual consulta deseja cancelar:
			<asp:DropDownList ID="ddlConsultas" runat="server" DataSourceID="ConsultasNaoRealizadasDS" DataTextField="Horário" DataValueField="idConsulta">
			</asp:DropDownList>
			&nbsp;<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
		</p>
	</asp:Panel>
	<asp:Panel ID="pnlConfirmacao" runat="server" Visible="False">
		Tem certeza que deseja cancelar a consulta com
		<asp:Label ID="lblConsulta" runat="server"></asp:Label>
		<br />
		<asp:Button ID="btnConfirmar" runat="server" OnClick="btnConfirmar_Click" Text="Confirmar" />
		&nbsp;<asp:Button ID="btnVoltar" runat="server" OnClick="btnVoltar_Click" Text="Ainda não" />
	</asp:Panel>
	<p __designer:mapid="49">
		<asp:Label ID="lblMensagem" runat="server" Visible="False"></asp:Label>
	</p>
	<p>
		<asp:SqlDataSource ID="ConsultasNaoRealizadasDS" runat="server" ConnectionString="<%$ ConnectionStrings:PRII16164ConnectionString %>" SelectCommand="pp3_sp_ConsultasNaoRealizadas" SelectCommandType="StoredProcedure">
			<SelectParameters>
				<asp:SessionParameter Name="paciente" SessionField="ID" Type="Int32" />
			</SelectParameters>
		</asp:SqlDataSource>
	</p>
</asp:Content>


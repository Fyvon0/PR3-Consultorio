<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PacienteAvaliarConsulta.aspx.cs" Inherits="PacienteAvaliarConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <asp:Label ID="lblMensagem" runat="server" Visible="False"></asp:Label>
    </p>
	<asp:Panel ID="pnlAvaliacao" runat="server">
		<p>
			Você está avaliando a consulta do dia
			<asp:Label ID="lblDia" runat="server"></asp:Label>
			&nbsp;realizada por
			<asp:Label ID="lblMedico" runat="server"></asp:Label>
		</p>
		<p>
			Como você avaliaria a qualidade da consulta com um valor de 1 a 10:</p>
		<p>
			<asp:TextBox ID="txtNota" runat="server" TextMode="Number"></asp:TextBox>
		</p>
		<p>
			Coloque aqui quaisquer observações acerca da consulta que você tiver:</p>
		<p>
			<asp:TextBox ID="txtObs" runat="server" Height="105px" TextMode="MultiLine" Width="348px"></asp:TextBox>
			<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
		</p>
		<p>
			<asp:Button ID="btnAvaliar" runat="server" OnClick="btnAvaliar_Click" Text="Avaliar" />
		</p>
	</asp:Panel>
</asp:Content>


﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Medico.aspx.cs" Inherits="Medico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Menu ID="Menu1" runat="server" StaticSubMenuIndent="16px" Orientation="Horizontal" DynamicHorizontalOffset="10" RenderingMode="List">
        <DynamicItemTemplate>
            <%# Eval("Text") %>
        </DynamicItemTemplate>
        <Items>
            <asp:MenuItem Text="Relatar Consulta" Value="Relatar Consulta" NavigateUrl="~/MedicoRelatarConsulta.aspx"></asp:MenuItem>
            <asp:MenuItem Text="Ver Consultas Marcadas" Value="Ver Consultas Marcadas" NavigateUrl="~/VerConsultas.aspx"></asp:MenuItem>
        </Items>
        <StaticMenuItemStyle HorizontalPadding="10px" />
    </asp:Menu>
    <table cellspacing="1" style="border: 1px solid #cde2a7" id="tablePaciente">
        <tr>
            <td rowspan="7" style="width: 154px">
                <asp:Image ID="image" runat="server" />
            </td>
            <td style="width: 277px; height: 23px;">Nome:
                <asp:Label ID="lblNome" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">Especialidade:
                <asp:Label ID="lblEspec" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">Data de Nascimento:
                <asp:Label ID="lblNasc" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">Email:
                <asp:Label ID="lblEmail" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">Telefone:
                <asp:Label ID="lblTel" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">Celular:
                <asp:Label ID="lblCel" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 277px;">
                <asp:Button ID="btnDeslogar" runat="server" OnClick="btnDeslogar_Click" Text="Deslogar" />
            </td>
        </tr>
    </table>
</asp:Content>


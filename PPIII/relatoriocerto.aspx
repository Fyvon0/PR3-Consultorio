<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="relatoriocerto.aspx.cs" Inherits="relatoriocerto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <h1>Relatórios de mediação</h1>

    <p>
        &nbsp;</p>
    <p>
        <table class="nav-justified">
            <tr>
                <td><h3>Consultas mensais por médico</h3></td>
                <td><h3>Atendimento diário por especialidade</h3></td>
            </tr>
            <tr>
                <td>
        <asp:Chart ID="GrafColunaConsultaMedico" runat="server">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                </td>
                <td>
        <asp:Chart ID="GrafPizzaEspecialidade" runat="server">
            <Series>
                <asp:Series ChartType="Pie" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                </td>
                
            </tr>
            
            <tr>
                <td><h3>Consultas por paciente</h3></td>
                <td><h3>Consultas canceladas por mês</h3></td>
            </tr>
            <tr>
                <td>
        <asp:Chart ID="GrafBarraConsultaPaciente" runat="server">
            <Series>
                <asp:Series ChartType="Bar" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                </td>
                <td>
        <asp:Chart ID="GrafColunaCancel" runat="server">
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
                </td>
            </tr>
        </table>
    </p>
    </asp:Content>


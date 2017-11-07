using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Drawing;

public partial class MedicoRelatarConsulta : System.Web.UI.Page
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            this.MasterPageFile = "~/SiteLogado.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
            Response.Redirect("~/Default");
        if ((string)Session["Usuario"] != "Medico")
            Response.Redirect("~/" + Session["Usuario"]);
        
        SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
        SqlCommand comando = new SqlCommand("select count(idConsulta) from pp3_v_ConsultasHoje",conexao);
        conexao.Open();
        int consultas = (int)comando.ExecuteScalar();

        if (consultas <= 0)
        {
            pnlMensagem.Visible = true;
            pnlEscolha.Visible = false;
            lblMensagem.Text = "Ainda não foram realizadas consultas hoje <a href = 'Medico.aspx'>Clique aqui para voltar para  Home </a>";
            lblMensagem.ForeColor = System.Drawing.Color.Orange;
            lblMensagem.BorderColor = ColorTranslator.FromHtml("#99FF99");
            lblMensagem.BorderStyle = BorderStyle.Solid;
            lblMensagem.BorderWidth = 1;
            lblMensagem.BackColor = ColorTranslator.FromHtml("#E7FFCE");
        }
        conexao.Close();
    }

    protected void btnEscolher_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
            SqlCommand comando = new SqlCommand("select idAnotacao from pp3_Consulta where idConsulta = @CONSULTA", conexao);
            comando.Parameters.AddWithValue("@CONSULTA", ddlConsultas.SelectedValue);
            conexao.Open();
            object Obs = comando.ExecuteScalar();

            if (Obs != DBNull.Value)
            {
                int idObs = (int)Obs;
                comando = new SqlCommand("select sintomas, exames, diagnostico, medicacao from pp3_Anotacao where idAnotacao = @IDOBS", conexao);
                comando.Parameters.AddWithValue("@IDOBS", idObs);
                SqlDataReader leitor = comando.ExecuteReader();
                if (leitor.Read())
                {
                    txtSintomas.Text = leitor.GetString(0);
                    txtExames.Text = leitor.GetString(1);
                    txtSintomas.Text = leitor.GetString(2);
                    txtMedicacao.Text = leitor.GetString(3);
                }
            }
            conexao.Close();
        }
        catch (Exception ex)
        {
            lblMensagem.Text = "Não foi possível conectar com o banco de dados. Desculpe-nos o incômodo.\nTente novamente mais tarde. <a href = 'Medico.aspx'>Clique aqui para voltar para  Home </a>";
        }

        pnlEscolha.Visible = false;
        lblConsulta.Text = ddlConsultas.SelectedItem.ToString();
        pnlConsulta.Visible = true;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlConsulta.Visible = false;
        pnlEscolha.Visible = true;
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
            SqlCommand comando = new SqlCommand("select idAnotacao from pp3_Consulta where idConsulta = @CONSULTA", conexao);
            comando.Parameters.AddWithValue("@CONSULTA", ddlConsultas.SelectedValue);
            conexao.Open();
            object Obs = comando.ExecuteScalar();

            if (Obs != DBNull.Value)
            {
                int idObs = (int)Obs;
                comando = new SqlCommand("update pp3_Anotacao set sintomas = @SINTOMAS, exames = @EXAMES, diagnostico = @DIAGNOSTICO, medicacao = @MEDICACAO where idAnotacao = @IDOBS", conexao);
                comando.Parameters.AddWithValue("@SINTOMAS", txtSintomas.Text);
                comando.Parameters.AddWithValue("@EXAMES", txtExames.Text);
                comando.Parameters.AddWithValue("@DIAGNOSTICO", txtDiagnostico.Text);
                comando.Parameters.AddWithValue("@MEDICACAO", txtMedicacao.Text);
                comando.Parameters.AddWithValue("@IDOBS", idObs);
                comando.ExecuteNonQuery();
                lblMensagem.Text = "As anotações da consulta foram atualizadas com sucesso. <a href = 'Medico.aspx'>Clique aqui para voltar para a Home </a>";
            }
            else
            {
                comando = new SqlCommand("pp3_sp_RelatarConsulta", conexao);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@CONSULTA", ddlConsultas.SelectedValue);
                comando.Parameters.AddWithValue("@DIAGNOSTICO", txtDiagnostico.Text);
                comando.Parameters.AddWithValue("@EXAMES", txtExames.Text);
                comando.Parameters.AddWithValue("@MEDICACAO", txtMedicacao.Text);
                comando.Parameters.AddWithValue("@SINTOMAS", txtSintomas.Text);
                comando.ExecuteNonQuery();
                lblMensagem.Text = "As anotações da consulta foram inseridas com sucesso. <a href = 'Medico.aspx'>Clique aqui para voltar para a Home </a>";
            }
            conexao.Close();
        }
        catch (Exception ex)
        {
            lblMensagem.Text = "Ocorreu um erro na comunicação com o banco de dados. Pedimos desculpas pelo incômodo. <a href = 'Medico.aspx'>Clique aqui para voltar para a Home </a>";
        }
    }
}
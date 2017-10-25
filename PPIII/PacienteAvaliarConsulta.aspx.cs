using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

public partial class PacienteAvaliarConsulta : System.Web.UI.Page
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            this.MasterPageFile = "~/SiteLogado.master";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["Usuario"] == null)
                Response.Redirect("~/Login");
            if (Session["Usuario"].ToString() != "Paciente")
                Response.Redirect("~/" + Session["Usuario"]);
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Login");
        }

        try
        {
            SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
            SqlCommand comando = new SqlCommand("select max(c.idConsulta), c.dataInicio, m.nome from pp3_Consulta c, pp3_Medico m where c.idPaciente = @PACIENTE and c.idMedico = m.idMedico", conexao);
            comando.Parameters.AddWithValue("@PACIENTE", Session["ID"]);

            conexao.Open();
            SqlDataReader leitor = comando.ExecuteReader();
            if (leitor.Read())
            {
                Session["IDConsulta"] = leitor.GetInt32(0);
                lblDia.Text = leitor.GetDateTime(1).ToString("dd/mm/yyyy");
                lblMedico.Text = leitor.GetString(2);
            }

            comando = new SqlCommand("select count(idAvaliacao) from pp3_Consulta where idConsulta = @CONSULTA and idAvaliacao = null", conexao);
            int avaliada = (int)comando.ExecuteScalar();
            if (avaliada > 0)
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "A última consulta já foi avaliada.";
                pnlAvaliacao.Visible = false;
            }
            conexao.Close();
        }
        catch (Exception ex)
        {
            lblMensagem.Visible = true;
            pnlAvaliacao.Visible = false;
            lblMensagem.Text = ex.Message;
        }
    }

    protected void btnAvaliar_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
            SqlCommand comando = new SqlCommand("exec pp3_sp_InserirAvaliacao", conexao);
            comando.Parameters.AddWithValue("@ID", Session["IDConsulta"]);
            comando.Parameters.AddWithValue("@NOTA", txtNota.Text);
            comando.Parameters.AddWithValue("@OBS", txtObs.Text);
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            Session.Remove("IDConsulta");
        }
        catch (Exception ex)
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = ex.Message;
        }
    }
}
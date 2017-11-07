using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

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
            SqlCommand comando = new SqlCommand("pp3_sp_UltimaConsulta", conexao);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PACIENTE", Session["ID"]);
            comando.Parameters.Add("@CONSULTA", SqlDbType.Int);
            comando.Parameters.Add("@DATAINICIO", SqlDbType.SmallDateTime);
            comando.Parameters.Add("@NOME", SqlDbType.VarChar, 50);
            comando.Parameters.Add("@SUCESSO", SqlDbType.Bit);
            comando.Parameters["@CONSULTA"].Direction = ParameterDirection.Output;
            comando.Parameters["@DATAINICIO"].Direction = ParameterDirection.Output;
            comando.Parameters["@NOME"].Direction = ParameterDirection.Output;
            comando.Parameters["@SUCESSO"].Direction = ParameterDirection.Output;

            conexao.Open();
            comando.ExecuteNonQuery();
            if (Convert.ToBoolean(comando.Parameters["@SUCESSO"].Value))
            {
                Session["IDConsulta"] = (int)comando.Parameters["@CONSULTA"].Value;
                lblDia.Text = ((DateTime)comando.Parameters["@DATAINICIO"].Value).ToString("dd/MM");
                lblMedico.Text = (string)comando.Parameters["@NOME"].Value;

                comando = new SqlCommand("select count (*) from pp3_Consulta where idConsulta = @CONSULTA and idAvaliacao IS NULL", conexao);
                comando.Parameters.AddWithValue("@CONSULTA", Session["IDConsulta"]);
                int avaliada = (int)comando.ExecuteScalar();
                if (avaliada <= 0)
                {
                    lblMensagem.Visible = true;
                    lblMensagem.Text = "A última consulta já foi avaliada. <a href = 'Paciente.aspx'>Clique aqui para voltar para  Home </a>";
                    pnlAvaliacao.Visible = false;
                }
                txtNota.Text = "1";
            }
            else
            {
                lblMensagem.Visible = true;
                lblMensagem.Text = "Você ainda não realizou nenhuma consulta. <a href = 'Paciente.aspx'>Clique aqui para voltar para  Home </a>";
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
            SqlCommand comando = new SqlCommand("exec pp3_sp_InserirAvaliacao @CONSULTA, @NOTA, @OBS", conexao);
            comando.Parameters.AddWithValue("@CONSULTA", Session["IDConsulta"]);
            comando.Parameters.AddWithValue("@NOTA", Convert.ToInt32(txtNota.Text));
            comando.Parameters.AddWithValue("@OBS", txtObs.Text);
            conexao.Open();
            comando.ExecuteNonQuery();
            conexao.Close();
            Session.Remove("IDConsulta");
            lblMensagem.Visible = true;
            lblMensagem.Text = "Obrigado pela avaliação! <a href = 'Paciente.aspx'>Clique aqui para voltar para  Home </a> ";
            pnlAvaliacao.Visible = false;
        }
        catch (Exception ex)
        {
            lblMensagem.Visible = true;
            lblMensagem.Text = ex.Message;
        }
    }
}
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
            lblMensagem.Text = "&nbsp&nbsp&nbspAinda não foram realizadas consultas hoje&nbsp&nbsp&nbsp";
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
        SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164"].ConnectionString);
        SqlCommand comando = new SqlCommand("select idObservacao from pp3_Consulta where idConsulta = @CONSULTA");
        comando.Parameters.AddWithValue("@CONSULTA", ddlConsultas.SelectedValue);
        conexao.Open();
        int idObs = (int)comando.ExecuteScalar();

        if(idObs != 0)
        {
            comando = new SqlCommand("select sintomas, exames, diagnostico, medicacao from pp3_Observacao where idObservacao = @IDOBS", conexao);
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

        pnlEscolha.Visible = false;
        lblConsulta.Text = ddlConsultas.Text;
        pnlConsulta.Visible = true;
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlConsulta.Visible = false;
        pnlEscolha.Visible = true;
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164"].ConnectionString);
        SqlCommand comando = new SqlCommand("select idObservacao from pp3_Consulta where idConsulta = @CONSULTA");
        comando.Parameters.AddWithValue("@CONSULTA", ddlConsultas.SelectedValue);
        conexao.Open();
        int idObs = (int)comando.ExecuteScalar();

        if (idObs != 0)
        {
            comando = new SqlCommand("update pp3_Observacao set sintomas = @SINTOMAS, exames = @EXAMES, diagnostico = @DIAGNOSTICO, medicacao = @MEDICACAO where idObservacao = @IDOBS", conexao);
            comando.Parameters.AddWithValue("@SINTOMAS", txtSintomas.Text);
            comando.Parameters.AddWithValue("@EXAMES", txtExames.Text);
            comando.Parameters.AddWithValue("@DIAGNOSTICO", txtDiagnostico.Text);
            comando.Parameters.AddWithValue("@MEDICACAO", txtMedicacao.Text);
            comando.Parameters.AddWithValue("@IDOBS", idObs);
            comando.ExecuteNonQuery();
        }
        else
        {
            comando = new SqlCommand("exec pp3_sp_RelatarConsulta", conexao);
            comando.Parameters.AddWithValue("@CONSULTA", ddlConsultas.SelectedValue);
            comando.Parameters.AddWithValue("@DIAGNOSTICO", txtDiagnostico.Text);
            comando.Parameters.AddWithValue("@EXAMES", txtExames.Text);
            comando.Parameters.AddWithValue("@MEDICACAO", txtMedicacao.Text);
            comando.Parameters.AddWithValue("@SINTOMAS", txtSintomas.Text);
            comando.ExecuteNonQuery();
        }
        conexao.Close();
    }
}
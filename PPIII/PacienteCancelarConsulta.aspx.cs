using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PacienteCancelarConsulta : System.Web.UI.Page
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
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        pnlConsulta.Visible = false;
        lblConsulta.Text = ddlConsultas.SelectedItem.ToString();
        pnlConfirmacao.Visible = true;
        lblMensagem.Visible = false;
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        pnlConfirmacao.Visible = false;
        pnlConsulta.Visible = true;
        lblMensagem.Text = "A consulta não foi cancelada. <a href = 'Paciente.aspx'>Clique aqui para voltar para a home</a>";
        lblMensagem.Visible = true;
    }

    protected void btnConfirmar_Click(object sender, EventArgs e)
    {
        SqlConnection conexao = new SqlConnection (WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
        SqlCommand comando = new SqlCommand("pp3_sp_CancelarConsulta", conexao);
        comando.CommandType = System.Data.CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@CONSULTA", ddlConsultas.SelectedValue);
        conexao.Open();
        comando.ExecuteNonQuery();
        conexao.Close();

        ddlConsultas.DataBind();

        pnlConfirmacao.Visible = false;
        pnlConsulta.Visible = true;

        lblMensagem.Text = "A consulta foi cancelada com sucesso. <a href = 'Paciente.aspx'>Clique aqui para voltar para a home</a>";
        lblMensagem.Visible = true;
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PacienteMarcarConsulta : System.Web.UI.Page
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

    protected void btnMarcarConsulta_Click(object sender, EventArgs e)
    {
        lblMensagem.Text = "";

        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        try
        {
            SqlCommand comando = new SqlCommand("pp3_sp_InserirConsulta", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PACIENTE", Session["ID"].ToString());
            comando.Parameters.AddWithValue("@MEDICO", ddlMedico.SelectedValue);
            DateTime horario = DateTime.ParseExact(txtData.Text + " " + txtHorario.Text, "yyyy-MM-dd hh:mm",
                                                  System.Globalization.CultureInfo.InvariantCulture);
            comando.Parameters.AddWithValue("@INICIO", horario);
            horario = horario.AddMinutes(Convert.ToDouble(ddlDuracao.SelectedValue));
            comando.Parameters.AddWithValue("@FIM", horario);
            comando.Parameters.Add("@SUCESSO", SqlDbType.Bit);
            comando.Parameters["@SUCESSO"].Direction = ParameterDirection.Output;
            comando.ExecuteNonQuery();

            if (!Convert.ToBoolean(comando.Parameters["@SUCESSO"].Value))
            {
                lblMensagem.Text = "Já existe uma consulta nesse horário";
                return;
            }
            else
                lblMensagem.Text = "Consulta cadastrada com sucesso";
        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }
    }
}
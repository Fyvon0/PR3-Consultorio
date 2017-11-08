using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerConsultas : System.Web.UI.Page
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
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        try
        {
            SqlCommand comando = new SqlCommand("pp3_VerConsultasMedico", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NOME", Session["Nome"]);
            DateTime horario = DateTime.ParseExact(txtData.Text, "yyyy-MM-dd",
                                                  System.Globalization.CultureInfo.InvariantCulture);
            comando.Parameters.AddWithValue("@DATA", horario);

            SqlDataReader rdr = comando.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();


            conexao.Close();

        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }
    }
}
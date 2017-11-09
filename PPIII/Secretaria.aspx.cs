using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Secretaria : System.Web.UI.Page
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
        if ((string)Session["Usuario"] != "Secretaria")
            Response.Redirect("~/" + Session["Usuario"]);

        string cs = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cs);
        SqlCommand comando = new SqlCommand("SELECT nome, email, celular FROM pp3_Secretaria WHERE idEspecialidade = " + Session["ID"], conexao);
        conexao.Open();
        byte[] imagem;
        SqlDataReader leitor = comando.ExecuteReader();
        if (leitor.Read())
        {
            lblNome.Text = leitor.GetString(0);
            lblEmail.Text = leitor.GetString(1);
            lblCel.Text = leitor.GetString(2);
        }
        conexao.Close();
    }
}
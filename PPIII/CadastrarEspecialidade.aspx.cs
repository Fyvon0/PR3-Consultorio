using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CadastrarEspecialidade : System.Web.UI.Page
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
    }

    protected void btnCadastrarEspecialidade_Click(object sender, EventArgs e)
    {
        lblMensagem.Text = "";

        //Verificação
        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        try
        {
            SqlCommand comando = new SqlCommand("pp3_sp_InserirEspec", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NOME", txtNomeEspec.Text);
            comando.Parameters.Add("@FALHA", SqlDbType.VarChar, 10);
            comando.Parameters["@FALHA"].Direction = ParameterDirection.Output;

            comando.ExecuteNonQuery();

            conexao.Close();

            lblMensagem.Text = "Inserção bem sucedida";
            lblMensagem.ForeColor = Color.Green;

            string erro = "";
            switch (comando.Parameters["@FALHA"].Value.ToString())
            {
                case "nome":
                    erro = "Já existe uma especialidade com esse nome \n";
                    lblMensagem.Text = erro;
                    lblMensagem.ForeColor = Color.Red;
                    break;
            }

        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }
    }
}
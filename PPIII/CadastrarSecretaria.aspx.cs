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

public partial class CadastrarSecretaria : System.Web.UI.Page
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

        lblMensagem.Text = "";        
    }

    protected void btnCadastrarSecretaria_Click(object sender, EventArgs e)
    {
        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        try
        {
            SqlCommand comando = new SqlCommand("pp3_sp_InserirSecretaria", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NOME", txtNomeSec.Text);
            comando.Parameters.AddWithValue("@EMAIL", txtEmailSec.Text);
            comando.Parameters.AddWithValue("@CELULAR", txtCelSec.Text);
            comando.Parameters.AddWithValue("@LOGIN", txtLoginSec.Text);
            comando.Parameters.AddWithValue("@SENHA", txtSenhaSec.Text);
            comando.Parameters.Add("@FALHA", SqlDbType.VarChar, 10);
            comando.Parameters["@FALHA"].Direction = ParameterDirection.Output;


            comando.ExecuteNonQuery();

            conexao.Close();

            lblMensagem.Text = "Inserção bem sucedida";
            lblMensagem.ForeColor = Color.Green;

            string erro = "";
            switch (comando.Parameters["@FALHA"].Value.ToString())
            {
                case "login":
                    erro = "Já existe uma secretaria com esse login \n";
                    lblMensagem.Text = erro;
                    lblMensagem.ForeColor = Color.Red;
                    break;
                case "nome":
                    erro = "Já foi cadastrada uma secretaria com esse nome \n";
                    lblMensagem.Text = erro;
                    lblMensagem.ForeColor = Color.Red;
                    break;
                case "email":
                    erro = "Já foi cadastrada uma secretaria com esse email \n";
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
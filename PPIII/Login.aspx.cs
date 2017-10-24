using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        if (Session["ID"] != null)
            Response.Redirect("~/Default");
    }

    protected void btnLogar_Click(object sender, EventArgs e)
    {
        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        try
        {
            SqlCommand comando = new SqlCommand("pp3_sp_Logar", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@LOGIN", txtLogin.Text);
            comando.Parameters.AddWithValue("@SENHA", txtSenha.Text);
            comando.Parameters.Add("@SUCESSO", SqlDbType.Bit);
            comando.Parameters.Add("@USUARIO", SqlDbType.VarChar, 10);
            comando.Parameters.Add("@ID", SqlDbType.Int);
            comando.Parameters.Add("@NOME", SqlDbType.VarChar, 50);
            comando.Parameters["@SUCESSO"].Direction = ParameterDirection.Output;
            comando.Parameters["@USUARIO"].Direction = ParameterDirection.Output;
            comando.Parameters["@ID"].Direction = ParameterDirection.Output;
            comando.Parameters["@NOME"].Direction = ParameterDirection.Output;


            comando.ExecuteNonQuery();
            conexao.Close();

            if (!Convert.ToBoolean(comando.Parameters["@SUCESSO"].Value))
            {
                lblMensagem.Text = "Combinação de senha e login inválida";
                return;
            }

            Session["ID"] = comando.Parameters["@ID"].Value;
            Session["Usuario"] = comando.Parameters["@USUARIO"].Value.ToString();
            Session["Nome"] = comando.Parameters["@NOME"].Value.ToString();
            Response.Redirect("~/"+ (string)Session["Usuario"]);
        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }
    }
}
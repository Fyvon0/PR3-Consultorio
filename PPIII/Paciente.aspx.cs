using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paciente : System.Web.UI.Page
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
        if ((string)Session["Usuario"] != "Paciente")
            Response.Redirect("~/"+Session["Usuario"]);

        string cs = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cs);
        SqlCommand comando = new SqlCommand("SELECT nome, endereco, dataAniversario, email,telefone,celular, foto FROM pp3_Paciente WHERE idPaciente = " + Session["ID"],conexao);
        conexao.Open();
        byte[] imagem;
        SqlDataReader leitor = comando.ExecuteReader();
        if (leitor.Read())
        {
            lblNome.Text = leitor.GetString(0);
            lblEnd.Text = leitor.GetString(1);
            lblNasc.Text = leitor.GetDateTime(2).ToString("dd/MM/yyyy");
            lblEmail.Text = leitor.GetString(3);
            lblTel.Text = leitor.GetString(4);
            lblCel.Text = leitor.GetString(5);
            imagem = (byte[])leitor["foto"];
            string base64String = Convert.ToBase64String(imagem, 0, imagem.Length);
            image.ImageUrl = "data:image/png;base64," + base64String;
            image.Height = 171;
        }
        conexao.Close();
    }

    protected void btnDeslogar_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Default");
    }
}
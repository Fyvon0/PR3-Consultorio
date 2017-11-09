using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Web.Configuration;

public partial class relatoriocerto : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        getConsultaMedico();
        getCanceladasMes();
        getaEspecialidadeDiaria();
        getConsultaPaciente();

        if (Session["Usuario"] == null)
            Response.Redirect("~/Default");
        if ((string)Session["Usuario"] != "Secretaria")
            Response.Redirect("~/" + Session["Usuario"]);
    }

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["ID"] != null)
            this.MasterPageFile = "~/SiteLogado.master";
    }

    private void getConsultaMedico()
    {
        SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
        SqlCommand comando = new SqlCommand("pp3_sp_NumeroDeConsultasPorMedico", conexao);
        conexao.Open();
        SqlDataReader leitor = comando.ExecuteReader();
 
        while(leitor.Read())
        {
            string nome   = leitor.GetString(0);
            double consultas = leitor.GetInt32(1);
            GrafColunaConsultaMedico.Series["Series1"].Points.AddXY(nome, consultas);
        }

    }

    private void getaEspecialidadeDiaria()
    {
        SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
        SqlCommand comando = new SqlCommand("pp3_sp_NumeroDeConsultasPorMedico", conexao);
        conexao.Open();
        SqlDataReader leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            string nome = leitor.GetString(0);
            double consultas = leitor.GetInt32(1);
            GrafPizzaEspecialidade.Series["Series1"].Points.AddXY(nome + " - " + Convert.ToString(consultas), consultas);
        }

    }

    private void getConsultaPaciente()
    {
        SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
        SqlCommand comando = new SqlCommand("pp3_sp_NumeroDeConsultasPorMedico", conexao);
        conexao.Open();
        SqlDataReader leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            string nome = leitor.GetString(0);
            double consultas = leitor.GetInt32(1);
            GrafBarraConsultaPaciente.Series["Series1"].Points.AddXY(nome, consultas);
        }

    }

    private void getCanceladasMes()
    {
        SqlConnection conexao = new SqlConnection(WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString);
        SqlCommand comando = new SqlCommand("pp3_sp_NumeroDeConsultasPorMedico", conexao);
        conexao.Open();
        SqlDataReader leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            string nome = leitor.GetString(0);
            double consultas = leitor.GetInt32(1);
            GrafColunaCancel.Series["Series1"].Points.AddXY(nome, consultas);
        }

    }
}

//pp3_sp_ConsultasPorEspecialidadeDiaria
//pp3_sp_NumeroConsultasPaciente
//pp3_sp_CanceladasMes
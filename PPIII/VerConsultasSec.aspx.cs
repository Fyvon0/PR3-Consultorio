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

public partial class VerConsultasSec : System.Web.UI.Page
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

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        if (RadioButtonList1.SelectedValue == "0")
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            txtData.Visible = true;
            txtData.Text = null;
          
        }
        if (RadioButtonList1.SelectedValue == "1")
        {
            txtData.Visible = false;

            try
            {
                SqlCommand comando = new SqlCommand("pp3_VerConsultasGeral", conexao);

                comando.CommandType = CommandType.StoredProcedure;

                SqlDataReader rdr = comando.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();


                conexao.Close();

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (GridView1.Rows[i].Cells[4].Text == "CANCELADA")
                    {
                        GridView1.Rows[i].BackColor = Color.Red;
                    }
                }

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }

    protected void txtData_TextChanged(object sender, EventArgs e)
    {
        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();
        if (txtData.Text != null)
            try
            {
                SqlCommand comando = new SqlCommand("pp3_VerConsultas", conexao);

                comando.CommandType = CommandType.StoredProcedure;
                DateTime data = DateTime.ParseExact(txtData.Text, "yyyy-MM-dd",
                                                      System.Globalization.CultureInfo.InvariantCulture);
                comando.Parameters.AddWithValue("@DATA", data);

                SqlDataReader rdr = comando.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();


                conexao.Close();

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    if (GridView1.Rows[i].Cells[4].Text == "CANCELADA")
                    {
                        GridView1.Rows[i].BackColor = Color.Red;
                    }
                }

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
    }
}
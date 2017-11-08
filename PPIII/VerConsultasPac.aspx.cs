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

public partial class VerConsultasPac : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblMensagem.Text = "";

        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        try
        {
            SqlCommand comando = new SqlCommand("pp3_VerConsultasPaciente", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@MEDICO", DropDownList1.SelectedValue);
            comando.Parameters.AddWithValue("@PACIENTE", Session["Nome"]);

            SqlDataReader rdr = comando.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();


            conexao.Close();

            if (DropDownList1.SelectedIndex != 0)
                if (GridView1.Rows.Count == 0)
                    lblMensagem.Text = "Nenhuma consulta com esse médico foi realizada.";

        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }
    }
}
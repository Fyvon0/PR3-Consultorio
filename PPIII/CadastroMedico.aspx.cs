using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CadastroMedico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnCadastrarPac_Click(object sender, EventArgs e)
    {
        lblMensagem.Text = "";
        //Response.Redirect("Secretaria.aspx");
        if (fupFoto.PostedFile == null || string.IsNullOrEmpty(fupFoto.PostedFile.FileName) || fupFoto.PostedFile.InputStream == null)
        {
            lblMensagem.Text = "Erro - Não foi possível enviar o arquivo.<br />";
            return;
        }

        /*
        //obtem a extensão do arquivo enviado  
        string extensao = Path.GetExtension(fupFoto.PostedFile.FileName).ToLower();

        string tipoArquivo = null;
        //efetua a validação do arquivo

        switch (extensao)
        {
            case ".jpg":
            case ".jpeg":
            case ".jpe":
                tipoArquivo = "image/jpeg";
                break;
            case ".png":
                tipoArquivo = "image/png";
                break;
            default:
                lblmsg.Text = "<br />Erro - tipo de arquivo inválido.<br />";
                return;
        }*/

        byte[] imageBytes = new byte[fupFoto.PostedFile.InputStream.Length + 1];
        fupFoto.PostedFile.InputStream.Read(imageBytes, 0, imageBytes.Length);


        //Verificação
        string cadeiaConexao = WebConfigurationManager.ConnectionStrings["PRII16164ConnectionString"].ConnectionString;
        SqlConnection conexao = new SqlConnection(cadeiaConexao);
        conexao.Open();

        try
        {
            SqlCommand comando = new SqlCommand("pp3_sp_InserirMedico", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NOME", txtNomeMed.Text);
            comando.Parameters.AddWithValue("@EMAIL", txtEmailMed.Text);
            comando.Parameters.AddWithValue("@DATAANIVERSARIO", txtDataNascMed.Text);
            comando.Parameters.AddWithValue("@CELULAR", txtCelMed.Text);
            comando.Parameters.AddWithValue("@TELEFONE", txtTelMed.Text);
            comando.Parameters.AddWithValue("@ESPECIALIDADE", ddlEspecialidade.SelectedValue);
            comando.Parameters.AddWithValue("@LOGIN", txtLoginMedico.Text);
            comando.Parameters.AddWithValue("@SENHA", txtSenhaMedico.Text);
            comando.Parameters.AddWithValue("@FOTO", imageBytes);
            comando.Parameters.Add("@FALHA", SqlDbType.VarChar, 10);
            comando.Parameters["@FALHA"].Direction = ParameterDirection.Output;


            comando.ExecuteNonQuery();

            conexao.Close();

            string erro = "";
            switch (comando.Parameters["@FALHA"].Value.ToString())
            {
                case "login":
                    erro = "Já existe um paciente com esse login \n";
                    break;
                case "nome":
                    erro = "Já foi cadastrado um paciente com esse nome \n";
                    break;
                case "email":
                    erro = "Já foi cadastrado um paciente com esse email \n";
                    break;
            }

            lblMensagem.Text += erro;
        }
        catch (Exception ex)
        {
            lblMensagem.Text = ex.Message;
        }
    }
}
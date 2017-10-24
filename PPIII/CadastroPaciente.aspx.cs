using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CadastroCliente : System.Web.UI.Page
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
            lblMensagem.Text = "Erro - Não foi possível enviar o arquivo<br />";
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
            SqlCommand comando = new SqlCommand("pp3_sp_InserirPaciente", conexao);

            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@NOME", txtNomePac.Text);
            comando.Parameters.AddWithValue("@ENDERECO", txtEnderecoPac.Text);
            comando.Parameters.AddWithValue("@DATAANIVERSARIO", txtDataNascPac.Text);
            comando.Parameters.AddWithValue("@EMAIL", txtEmailPac.Text);
            comando.Parameters.AddWithValue("@TELEFONE", txtTelPac.Text);
            comando.Parameters.AddWithValue("@CELULAR", txtCelPac.Text);
            comando.Parameters.AddWithValue("@FOTO", imageBytes);
            comando.Parameters.AddWithValue("@LOGIN", txtLoginPac.Text);
            comando.Parameters.AddWithValue("@SENHA", txtSenhaPac.Text);
            comando.Parameters.Add("@FALHA", SqlDbType.VarChar, 10);
            comando.Parameters["@FALHA"].Direction = ParameterDirection.Output;


            comando.ExecuteNonQuery();

            conexao.Close();

            string erro = "";
            switch (comando.Parameters["@FALHA"].Value.ToString())
            {
                case "login":
                    erro = "Já existe um paciente com esse login <br />";
                    break;
                case "nome":
                    erro = "Já foi cadastrado um paciente com esse nome <br />";
                    break;
                case "email":
                    erro = "Já foi cadastrado um paciente com esse email <br />";
                    break;
            }
     
            lblMensagem.Text += erro;
        }
        catch (Exception ex)
        {
            lblMensagem.Text += "Erro ao conectar com o banco de dados";
        }
    }
}
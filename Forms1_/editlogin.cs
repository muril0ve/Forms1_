using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Data.SqlClient;
using InvestimentosMais;

namespace Forms1_
{
    public partial class editlogin : Form
    {

        private int Id;



        public editlogin()
        {
            InitializeComponent();
            UpdateListView();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();


            UserDAO userDAO = new UserDAO();
            List<User> users = userDAO.SelectUser();

            try
            {
                foreach (User user in users)
                {
                    ListViewItem lv = new ListViewItem(user.Id.ToString());

                    lv.SubItems.Add(user.Nome);
                    lv.SubItems.Add(user.Email);
                    lv.SubItems.Add(user.Cpf);

                    listView1.Items.Add(lv);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }


        }
        private void button2_Click(object sender, EventArgs e)
        {

            User user = new User(Id, email.Text, cpf.Text, Nome.Text);
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.UpdateUser(user);
            email.Clear();

            Nome.Clear();
            cpf.Clear();

            UpdateListView();
            MessageBox.Show("Atualizado com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
            UpdateListView();

        }



        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserDAO nomeDoObj = new UserDAO();
            nomeDoObj.DeleteUser(Id);
            email.Clear();

            cpf.Clear();
            Nome.Clear();


            MessageBox.Show("Excluido com sucesso",
           "AVISO",
           MessageBoxButtons.OK,
           MessageBoxIcon.Information);
            UpdateListView();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;

            index = listView1.FocusedItem.Index;
            Id = int.Parse(listView1.Items[index].SubItems[0].Text);
            Nome.Text = listView1.Items[index].SubItems[1].Text;
            email.Text = listView1.Items[index].SubItems[2].Text;
            cpf.Text = listView1.Items[index].SubItems[3].Text;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void senha_TextChanged(object sender, EventArgs e)
        {

        }

        private void nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private static bool VerificarUsuarioExistenteAddress(string nomeUsuario)
        {
            connection connection = new connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = "SELECT COUNT(*) FROM login WHERE email = @email";

            sqlCommand.Parameters.AddWithValue("@verificar", nomeUsuario);

            int count = (int)sqlCommand.ExecuteScalar();

            return count > 0;
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void imprimir_Click(object sender, EventArgs e)

        {
            string nomeUsuario = Nome.Text;
            bool loginExiste = VerificarUsuarioExistenteAddress(nomeUsuario);

            for (; ; )
            {
                if (loginExiste)
                {
                    string email, senha, nome, cpf;

                    connection connection = new connection();
                    SqlCommand sqlCommand = new SqlCommand();

                    sqlCommand.Connection = connection.ReturnConnection();
                    sqlCommand.CommandText = "SELECT * FROM CreateAccount WHERE usuario = @user";
                    sqlCommand.Parameters.AddWithValue("@user", Nome.Text);

                    if (Nome.Text == "")
                    {
                        MessageBox.Show(
                        "preencha o nome de usuário!",
                        "MONDIAL™",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        Nome.Clear();
                    }
                    else
                    {
                        using (SqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            reader.Read();
                            email = (string)reader["email"];
                            senha = "**";
                            nome = (string)reader["nome"];
                            ;
                        }

                        sqlCommand.CommandText = "SELECT * FROM login WHERE usuario = @user";

                        using (SqlDataReader reader1 = sqlCommand.ExecuteReader())
                        {
                            reader1.Read();

                            email = (string)reader1["email"];
                            senha = (string)reader1["senha"];
                            nome = (string)reader1["nome"];
                            cpf = (string)reader1["cpf"];


                        }
                        string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string archivename = "relatorio_" + Nome.Text + ".pdf";
                        string caminhoCompleto = Path.Combine(caminho, archivename);
                        FileStream archivePDF = new FileStream(caminhoCompleto, FileMode.Create);
                        Document doc = new Document(PageSize.A4);
                        PdfWriter pdfwriter = PdfWriter.GetInstance(doc, archivePDF);

                        string dados = "";

                        Paragraph paragraph = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, (int)System.Drawing.FontStyle.Bold));
                        paragraph.Alignment = Element.ALIGN_CENTER;
                        paragraph.Add("RELATÓRIO - MONDIAL");

                        Paragraph paragraphuser = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 12, (int)System.Drawing.FontStyle.Regular));
                        paragraphuser.Alignment = Element.ALIGN_CENTER;
                        paragraphuser.Add("Dados do Usuário:\n" + "Usuário: " + "\nSenha: " + senha + "\n CPF: " + cpf + "\nE-mail: " + email);


                        doc.Open();
                        doc.Add(paragraph);
                        doc.Add(paragraphuser);

                        doc.Close();

                        MessageBox.Show(
                        "O relatório foi criado com sucesso e armazenado na sua área de trabalho!",
                        "MONDIAL™",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                        break;
                    }
                }
                else
                {
                    MessageBox.Show(
                    "O nome de usuário é inválido!",
                    "MONDIAL™",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    break;

                }
            }
        }
    }
}


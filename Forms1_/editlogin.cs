using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
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



        private void nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void imprimir_Click(object sender, EventArgs e)
        {
            string connectionString = "DESKTOP-MBDNUGB\\SQLEXPRESS"; // Substitua pela sua string de conexão
            string query = "SELECT * FROM login";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        using (FileStream fs = new FileStream("relatorio.pdf", FileMode.Create))
                        {
                            using (Document doc = new Document())
                            {
                                using (PdfWriter pdfWriter = PdfWriter.GetInstance(doc, fs))
                                {
                                    doc.Open();

                                    while (reader.Read())
                                    {
                                        string email = reader["email"].ToString();
                                        string senha = "***"; // Substitua pelo valor que você deseja exibir para senha
                                        string nome = reader["nome"].ToString();
                                        string cpf = reader["cpf"].ToString();

                                        // Correção: Use o iTextSharp.text.Paragraph ao invés de System.Windows.Forms.Paragraph
                                        iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph();
                                        paragraph.Add("Email: " + email + "\n");
                                        paragraph.Add("Senha: " + senha + "\n");
                                        paragraph.Add("Nome: " + nome + "\n");
                                        paragraph.Add("CPF: " + cpf + "\n\n");

                                        doc.Add(paragraph);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            MessageBox.Show("PDF gerado com sucesso.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}




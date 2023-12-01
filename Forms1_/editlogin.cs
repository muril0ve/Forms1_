using System;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using InvestimentosMais;
using System.Net;
using System.Net.Mail;



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
            //aqui temos o botao de gera o pdf a partir das colunas do nosso banco de dados 
            // Conexão com o banco de dados SQL Server
            string stringConnection = @"Data Source="
                     + Environment.MachineName +
                     @"\SQLEXPRESS;Initial Catalog=" +
                     "PR2" + ";Integrated Security=true";
            SqlConnection connection = new SqlConnection(stringConnection);
            connection.Open();

            // Consulta SQL para recuperar as informações
            string query = "SELECT email, nome, cpf FROM login";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Cria um novo documento PDF
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("arquivo.pdf", FileMode.Create));
            document.Open();

            // Cria uma nova tabela e adiciona as informações recuperadas
            PdfPTable table = new PdfPTable(3);
            table.AddCell("Email");
           
            table.AddCell("Nome");
            table.AddCell("Cpf");
            

            while (reader.Read())
            {
                table.AddCell(reader["Email"].ToString());
               
                table.AddCell(reader["Nome"].ToString());
                table.AddCell(reader["Cpf"].ToString());
            }

            // Adiciona a tabela ao documento
            document.Add(table);

            // Fecha o documento e a conexão com o banco de dados
            document.Close();
            connection.Close();

            MessageBox.Show(
            "RELATORIO GERADO COM SUCESSO",
            "ATENÇÃO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
    }
}





